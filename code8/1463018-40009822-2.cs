	namespace DocumentManager.WebApi.Controllers
	{
		[RoutePrefix("api/document")]
		public class DocumentController : BaseController
		{
			[Route("get/{id}")]
			public IHttpActionResult Get(int id)
			{
				return Ok(DACDocument.Read(new DataContext(),id));
			}
		}
	}
