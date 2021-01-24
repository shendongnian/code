    public class AdditionController : ApiController
    {
        public IHttpActionResult Get(int firstNumber, int secondNumber)
        { 
            // I am just returning the numbers but you can call the Java Service
            return Ok($"{firstNumber} + {secondNumber}");
        }
    }
