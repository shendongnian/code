    [RoutePrefix("api")]
    public class LandingPageController : ApiController
    {
    	[Route("{unit}/{begdate}/{enddate}", Name = "QuadrantData")]
        public HttpResponseMessage GetQuadrantData(string unit, string begdate, string enddate)
        {
            ...
