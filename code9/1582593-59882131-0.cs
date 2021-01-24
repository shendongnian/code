csharp
[Route("api/[controller]")]
[ApiController]
public class DownloadController : ControllerBase
{
    [HttpGet("{name}")]
    [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
    public async Task<IActionResult> GetFile(string fileName)
    {
        var filePath = $"files/{fileName}"; // get file full path based on file name
        if (!System.IO.File.Exists(filePath))
        {
            return BadRequest();
        }
        return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", fileName);
    }
}
