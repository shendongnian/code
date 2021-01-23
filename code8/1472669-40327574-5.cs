        [HttpPost]
        public JsonResult Login([FromBody]object loginParam)
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
            return Json("OK");
        }
