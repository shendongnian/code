	[RoutePrefix("api/upload")]
	public class UploadController : ApiController
	{
		[HttpPost]
		[Route]
		public async Task<IHttpActionResult> Upload()
		{
			var result = await Request.Content.ReadAsMultipartAsync();
			if(result.Contents.Any())
			{
				var postedFile = await result.Contents.First().ReadAsStringAsync();
				// do something
				return Ok("File uploaded successfully");
			}
			return BadRequest("No files uploaded");
		}
	}
