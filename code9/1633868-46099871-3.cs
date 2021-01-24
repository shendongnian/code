    namespace MyAPIDLL
    {    
        [Route("api/[controller]")]
        public class RegistrationApi : Controller{
        
            [HttpPost()]
            [Route("SignOn")] // Matches POST api/RegistrationApi/SignOn
            public async Task<IActionResult> SignOn([FromBody]SignOnRequest model) {
                if(ModelState.IsValid) {                
                    var response = await _accountRepository.SignOn(model.emailAddress, model.password);
                    return Ok(response);
                }
                return BadRequest();
            }
        }
    }
