	[RoutePrefix("api/WebApI")]
	public class WebApIController : ApiController {
	
		[HttpPost] 
		[Route("callBcknd")]
		public IHttpActionResult CallBcknd([FromBody] ApiModel body)
		{
			try
			{
				Log.Info(string.Format("{0}", body.Content));
				return Ok(new {Message = "It worked!"});
			}
			catch(Exception ex)
			{
				// example of how to return error with content. I would not recommend actually returning the exception details to the client in a production setting
				return base.Content(HttpStatusCode.InternalServerError, ex.ToString());
			}
		}
    }
