    public class AdditionController : ApiController
    {
        public async Task<IHttpActionResult> Get(int firstNumber, int secondNumber)
        { 
            var result = await restfulClient.addition(firstNumber, secondNumber);
            return Ok(result);
        }
    }
