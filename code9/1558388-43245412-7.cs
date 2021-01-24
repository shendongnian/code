        [HttpGet]
        public ActionResult SaveAddress()
        {
            //Write your code here      
            return View();
        }
       [HttpPost]
        public ActionResult SaveAddress(MyClass myclass)
        {
            //Write your code here      
            return RedirectToAction();
        }    
