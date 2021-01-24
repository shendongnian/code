        public class Temp
        {
          public string firstNumber{ get;set;}
          public decimal secondNumber{ get;set;}
          public decimal sum{ get;set;}
        }
        
       
        public class AdditionController : ApiController
        {
         private RestfulClient restfulClient = new RestfulClient();
         public async Task<IHttpActionResult> Get(int firstNumber, int secondNumber)
         {
            var result = await restfulClient.addition(firstNumber, secondNumber);
            var resultDTO = JsonConvert.DeserializeObject<Temp>(result);
            return Json(resultDTO);
         }
        } 
