     public ActionResult SendEmail(string msg)
        {
            var sent = false;
            try
            {
               
                var emailClient = new EmailServiceReference.EmailServiceClient();
                sent = emailClient.SendEmail(fromEmail, toEmail, emailsubject, msg);  /// All parameters of SendEmail method defined
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured while sending Email " + ex.Message);
            }
            return Json(sent, JsonRequestBehavior.AllowGet);
        }
