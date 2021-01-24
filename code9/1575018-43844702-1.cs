	[RoutePrefix("api/ApiAcademic")]
	public class ApiAcademicController : ApiController
	{
		
		[HttpPost]
		[Route("InsertAcademicInfo")]
		public IHttpActionResult InsertAcademicInfo(AcademicInfoModel model)
		{
			 return Ok(_academic.InsertAcademicInformation(model.param1, model.param2).Data);
		}
	}
