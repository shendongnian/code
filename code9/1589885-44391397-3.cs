     using System.Web.Http;
     [RoutePrefix("api/Customer")]
        public class CustomerController : ApiController
        {
            [HttpGet]
            [Route("Create")]
            public MISApiResult<List<Branch>> Create(string userID, string password)
            {
                return new MISApiResult<List<Branch>>() { Result = new List<Branch>() { new Branch() { ID = Guid.NewGuid(), Name = "Branch1" } }, ResultCode = 1, ResultMessage = "Sucess" };
            }
        }
