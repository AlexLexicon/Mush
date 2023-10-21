using Lexicom.AspNetCore.Controllers.Amenities;
using Microsoft.AspNetCore.Mvc;

namespace Mush.Server.Api.Controllers;
[ApiController]
[Route("api/lobby")]
public class LobbyController : LexicomController
{
    [HttpGet]
    public IActionResult GetTest()
    {
        return Ok("test");
    }
}
