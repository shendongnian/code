    [HttpPost]
    public class StudentController : ApiController
    {    
        public void PostSomething([FromBody] StudentTransferObject studentInformation) 
        {
            //do something
        }
    }
