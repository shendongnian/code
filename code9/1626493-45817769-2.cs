        public class MyDataFormatController : ApiController
        {
            List<Data> data = new List<Data>();
    
            public MyResult<Data> Get()
            {
                data.Add(new Data { id = 1, role = "admin" });
                data.Add(new Data { id = 2, role = "manager" });
                data.Add(new Data { id = 3, role = "employee" });
    
                return new MyResult<Data>(data);
            }
    
            [Route("api/mydataformat/errormessage")]
            public MyResult<Data> GetError()
            {
                return new MyResult<Data>("No Data");
            }
    
            [Route("api/mydataformat/errorwithcode")]
            public MyResult<Data> GetErrorWithCode()
            {
                return new MyResult<Data>(new error { code = 101, message = "Invalid Data" });
            }
        }
