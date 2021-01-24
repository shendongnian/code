        public class UserController : CTControllerBase
        {
            //API
            [AllowAnonymous]
            [HttpPost]
            public ResponseModel USerApiTest([FromBody] RequestModel request)
            {
                // to handle the code
                ResponseModel res = new ResponseModel ();
                List<UserResult> results = new List<UserResult>();
                foreach( var user in request.ReqDtl)
                {
                       if(//Status should be Success)
                       {
                            results.Add( new UserResult{ ID=user.ID,Status = "Success"};
                       }
                       else 
                       {
                             results.Add(new UserResult{ ID=user.ID, Status = "Fail"};
                      }
                 }
 
                 res.ResDtl= results.ToArray();
                 res.ResLen=request.ReqLen;
                 return res;
            }
        }
        
        public class RequestModel
        {
            public int ReqLen { get; set;}
            public User[] ReqDtl { get; set; }
        }
         public class ResponseModel 
         {
             public int ResLen { get; set; }
             public UserResult[] ResDtl { get; set; }
         }
        public class User
        {
            public int ID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        public class UserResult
        {
              public int ID { get; set; }
              public string Status { get; set; }
         }
    }
