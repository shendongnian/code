	public class JobPosition
	{
		public int Id { set; get; }
		public string Title { set; get; }
		public IFormFile jobFile {set; get; }
	}
	[HttpPost]
	[Route("Job")]
	public async Task<bool> Post(JobPosition job)
	{
		if (!Request.ContentType.Contains(ConfigurationConstants.MultiPartFormDataContentType))
		{
			return BadRequest();
		}
		
		// your implementation
		// you can access the file by job.jobFile
		// you can read the contents of the file by opening a read stream from the file object and read it to a byte[]
		return true;
	}
