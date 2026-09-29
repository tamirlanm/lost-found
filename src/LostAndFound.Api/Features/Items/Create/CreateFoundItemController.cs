using LostAndFound.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using LostAndFound.Api.Features.Items;

namespace LostAndFound.Api.Features.Items.Create;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/items")]
[Authorize]
[RequiredScope("access_sa_user")]
public sealed class CreateFoundItemController(AppDbContext db) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateFoundItemRequest request,
        CancellationToken cancellationToken)
    {
        if(!Guid.TryParse(User.GetObjectId(), out var userId) || userId == Guid.Empty)
        {
            return Unauthorized();
        }

        var foundAt = request.FoundAt!.Value.ToUniversalTime();

        if(foundAt > DateTimeOffset.UtcNow)
        {
            ModelState.AddModelError(nameof(request.FoundAt), "Дата находки не может быть в будущем.");

            return ValidationProblem(ModelState);
        }

        var item = new FoundItem(
            userId,
            request.Name.Trim(),
            request.Description.Trim(),
            request.Category!.Value,
            request.Cabinet.Trim(),
            FoundItemStatus.Open,
            foundAt.UtcDateTime,
            null
        );

        db.FoundItems.Add(item);

        await db.SaveChangesAsync(cancellationToken);

        return Created($"/api/items/{item.Id}", new CreateFoundItemResponse(item.Id, item.CreatedAt));
    }
}

public sealed record CreateFoundItemResponse(
    Guid Id,
    DateTimeOffset CreatedAt
);