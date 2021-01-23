    public class SampleController : ControllerBase
    {
        public async Task<IActionResult> FooAsync(int? id)
        {
            if (id == 0)
            {
                // returned "NotFoundResult" base type "StatusCodeResult"
                return NotFound();
            }
            if (id == 1)
            {
                // returned "StatusCodeResult" base type "StatusCodeResult"
                return StatusCode(StatusCodes.Status415UnsupportedMediaType);
            }
            // returned "OkObjectResult" base type "ObjectResult"
            return new OkObjectResult("some message");
        }
    }
