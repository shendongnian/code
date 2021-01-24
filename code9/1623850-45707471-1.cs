    public class SendPDFController : ApiController
    {
		[HttpPost]
		public HttpResponseMessage Post([FromUri]ReportModel reportModel)
		{
		    //Perform Logic
		    return Request.CreateResponse(System.Net.HttpStatusCode.OK, reportModel);
        }
    }
