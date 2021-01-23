    public class SampleController : ControllerBase
    {
        public async Task<IActionResult> FooAsync(int? id)
        {
            if (id == 0)
            {
                // returned "NotFoundResult"
                return NotFound();
            }
            if (id == 1)
            {
                // returned "StatusCodeResult"
                return StatusCode(StatusCodes.Status415UnsupportedMediaType);
            }
            // returned "OkObjectResult"
            return new OkObjectResult("some message");
        }
    }
