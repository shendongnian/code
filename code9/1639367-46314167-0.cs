        [HttpPost]
        public ActionResult authenticateUser(FormCollection formCollection)
        {
            int token = int.Parse(formCollection["txtToken"]);
            string pswd = formCollection["txtPswd"];
            return View();
        }
