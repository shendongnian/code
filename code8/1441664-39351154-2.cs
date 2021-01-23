    [RoutePrefix("api")]
    public class LandingPageController : ApiController
    {
    	[Route("{unit}/{begdate}/{enddate}", Name = "QuadrantData")]
        public IHttpActionResult GetQuadrantData(string unit, string begdate, string enddate)
        {
            ...
