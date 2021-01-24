        public string _User_Id;
        public void ge_tUserIdFromSessions()
        {
            //in a controller you can use :         
            //_User_Id = HttpContext.Session.GetString("UserId");
            //but in a class U can use:
            var httpContextAccessor = new HttpContextAccessor();
            _User_Id = httpContextAccessor.HttpContext.Session.GetString("UserId");
            
        }
