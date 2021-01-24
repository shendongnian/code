    public class ChangePasswordController : ApiController
    {
        public class LoginVm
        {
            public string Email { set; get; }
            public string Pwd { set; get; }
        }
    
        [HttpPost]
        public HttpResponseMessage Post([FromBody] LoginVm vm)
        {
            try
            {
                wcfClinetProxy.ChangePassWord(vm.Email, vm.Pwd);
                return Request.CreateResponse(HttpStatusCode.OK,new {status = "success"});
            }
            catch (Exception ex)
            {
                // to do : Log the error (ex) to your error logs
                return Request.CreateResponse(HttpStatusCode.OK, 
                                  new { status = "failed", message="failed t update" });
            }
        }
    }
