using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.Identity.Web;

namespace LostAndFound.Api.Features.Identity;

[ApiController]
[Route("api/me")]
[Authorize]
[RequiredScope("access_as_user")]
public sealed class MeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var userId = User.GetObjectId();
        if (userId is null)
        {
            return Unauthorized();
        }

        return Ok(new {userId});
    }
}