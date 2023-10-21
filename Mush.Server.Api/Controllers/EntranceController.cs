using Lexicom.AspNetCore.Controllers.Amenities;
using Microsoft.AspNetCore.Mvc;
using Mush.Server.Api.Contracts;

namespace Mush.Server.Api.Controllers;
[ApiController]
[Route("api/entrance")]
public class EntranceController : LexicomController
{
    [HttpGet]
    public async Task<IActionResult> HostAsync()
    {
        return Ok(new EntranceHostGetResponseBody
        {

        });
    }

    [HttpPost]
    public async Task<IActionResult> JoinAsync()
    {
        return Ok(new EntranceJoinPostRequestBody
        {

        });
    }
}
