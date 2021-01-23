        [HttpPost]
        public ActionResult Login(string loginParam)
        {
            if (loginParam != null)
            {
                Console.WriteLine("Login Data Recieved");
            }
            else
            {
                Console.WriteLine("Login Data is NULL");
            }
            Console.WriteLine(loginParam);
            return new JsonResult() { Data = "Ok" };
        }
