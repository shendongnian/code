    [RoutePrefix("api")]
    public class LandingPageController : ApiController {
    
        [HttpGet]
        [Route("{unit}/{begdate}/{enddate}", Name="QuadrantData")]
        public HttpResponseMessage GetQuadrantData(string unit, string begdate, string enddate) {
            _unit = unit;
            _beginDate = begdate;
            _endDate = enddate;
            //...other code
        }
        //...other code
    }
