    public class PersonController : ApiController  
    {
        [HttpPost]
        public Person Index([FromBody]Person Person,  [FromBody]Building Building)
        {
            return Person;
        }
    }
