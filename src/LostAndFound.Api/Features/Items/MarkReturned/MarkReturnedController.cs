using LostAndFound.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;

namespace LostAndFound.Api.Features.Items.MarkReturned;

[ApiController]
[Route("api/items")]
[Authorize]
[RequiredScope("access_as_user")]
public sealed class MarkReturnedController(AppDbContext db) : ControllerBase
{
    [HttpPatch("{id:guid}/returned")]
    public async Task<IActionResult> MarkReturned(
        Guid id,
        CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(User.GetObjectId(), out var userId)
            || userId == Guid.Empty)
        {
            return Unauthorized();
        }

        var item = await db.FoundItems
            .SingleOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);

        if (item is null)
            return NotFound();

        if (item.UserFoundId != userId)
            return Forbid();

        item.MarkReturned();

        await db.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}