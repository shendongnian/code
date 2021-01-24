     [RoutePrefix("Customer")]
        public class CustomerController : ApiController
        {
            [System.Web.Mvc.AcceptVerbs("GET", "POST")]
            [System.Web.Mvc.HttpGet]
            [Route("Create")]
            public MISApiResult<List<Branch>> Create(string userID, string password)
            {
                return new MISApiResult<List<Branch>>() { Result = new List<Branch>() { new Branch() { ID = Guid.NewGuid(), Name = "Branch1" } }, ResultCode = 1, ResultMessage = "Sucess" };
            }
        }
