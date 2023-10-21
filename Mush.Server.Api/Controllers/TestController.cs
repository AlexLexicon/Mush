using Lexicom.AspNetCore.Controllers.Amenities;
using Microsoft.AspNetCore.Mvc;

namespace Mush.Server.Api.Controllers;
[ApiController]
[Route("api/test")]
public class TestController : LexicomController
{
    [HttpGet]
    public IActionResult GetTest()
    {
        return Ok("test");
    }
}
