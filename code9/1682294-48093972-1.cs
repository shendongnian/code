    [HttpPost]
        // Receive parameters what you are passing
        public ActionResult MemberInformation_Detail(string name, string FName)
        {
            // return proper json object that contains all properties that you are using in js
            return Json(new { MemberShipID = 123, name = "Test", FName = "Fathename", Gender = "Male", address = "N/A", phone1 = "123456789", mobileno = "123456789", email = "abc@abc.com", ClientPic = "clientpic" });
        }
    
