    public class MyObjController : BaseController
    {
        [HttpGet]
        [ActionName("GetMyObjList")]
        public HttpResponseMessage GetMyObjList(string UserName, string UserPass)
        {//Here you can check the credentials and retrieve data from the database and return them back to the client...
            object result = null;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
