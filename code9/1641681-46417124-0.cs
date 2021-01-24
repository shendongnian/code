    public class WebJobResponseController : ApiController
    {
        public string Get(string token, string value)
        {
            //use the token to validate the webjob, use the value to post any data which you want to send to API
            return "success";
        }
    }
