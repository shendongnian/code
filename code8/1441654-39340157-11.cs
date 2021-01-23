    [RoutePrefix("api")]
    public class LandingPageController : ApiController {
    
        //eg POST api/QuadrantData
        [HttpPost]
        [Route("QuadrantData", Name="GenerateQuadrantData")]
        public HttpResponseMessage QuadrantData(string unit, string begdate, string enddate) {
            _unit = unit;
            _beginDate = begdate;
            _endDate = enddate;
            //...other code
        }
        //...other code
    }
