    public class FileController : BaseController
    {
    	[HttpPost("customer/{customerId}/file", Name = "UploadFile")]
    	[SwaggerResponse(StatusCodes.Status201Created, typeof(UploadFileResponse))]
    	[Consumes("application/octet-stream", new string[] { "application/pdf", "image/jpg", "image/jpeg", "image/png", "image/tiff", "image/tif"})]
        public async Task<IActionResult> UploadFile([FromBody] Stream file, [FromRoute] string customerId, [FromQuery] FileQueryParameters queryParameters)
    	{
    		// file processing here
    	}
    }
