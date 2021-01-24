    [RoutePrefix("api/presidents")]
    public class PresidentsController : ApiController
    {
        [Route("GetFirstPresident/{countryName}")]
        public IHttpActionResult GetFirstPresident(string countryName)
        {
            var president = string.Format("First president of {0} was XYZ", countryName);
            return Ok(president);
        }
        [Route("GetPresident/{number}/{countryName}")]
        public IHttpActionResult GetPresident(int number, string countryName)
        {
            var president = string.Format("{1} president of {0} was XYZ", countryName, number);
            return Ok(president);
        }
    }
