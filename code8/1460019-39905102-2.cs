	[HttpPost()] 
	[Route("PostLog")]
	public void PostLog(LogContainerModel logModel)
	{
		_LogService.PostLog(logModel.log);
	}
	// model
	public sealed class LogContainerModel {
		public string log { get; set; }
	}
