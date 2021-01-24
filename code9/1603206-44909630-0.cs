    public ActionResult sendEmail(string userName, string userEmail,string userPhone, string userAddress, string userSubject, string userMessage, string userList)
    {
           ///code to send mail - works no problem
            if (!ok)
            {
                //  Send "false"
                var response = new { success = false, responseText = "FAIL" };
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(response), "application/json");
            }
            else
            {
                //  Send "Success"
                var response = new { success = true, responseText = "Your message successfuly sent!" };
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(response), "application/json");
            }
    }
