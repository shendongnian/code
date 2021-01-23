        public ActionResult Your_Method()
        {
            //... your auth login  .... 
    
            //Load email setting from config
            var EmailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            var EmailTo = ConfigurationManager.AppSettings["EmailTo"];
            var EmailSubject = ConfigurationManager.AppSettings["EmailSubject"];
        
            var currentUser = //your current user data for example from session or from the code/database;
            try
            {
                    if (currentUser != null)
                    {
                        using (var smtp = new SmtpClient())
                        {
                            using (var message = new MailMessage())
                            {
                                var from = new MailAddress(EmailFrom);
                                var to = new MailAddress(EmailTo);
        
                                message.To.Add(to);
                                message.From = from;
                                message.Subject = EmailSubject;
                                message.IsBodyHtml = true;
                                message.Body = $@"
        Dear user: {currentUser.FName ?? string.Empty} {currentUser.LName ?? string.Empty}  <br/>
        Welcome to our website! Your id: {currentUser.Id ?? string.Empty} <br/>
        Other information: {currentUser.information ?? string.Empty} <br/>
        <br/>
        <br/>
        Contact Us Email : {"website@website.ru"}<br/>
        Contact Us Phone : {"+7 913 123 4567"} <br/>
        ";
                                smtp.Send(message);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Log your exception somethere
                //e.HandleException(LogLevel.Fatal);
            }
        
            //And then you can return some JSON 
            var response = JsonConvert.SerializeObject(your_return_object);
            return new ContentResult {Content = response, ContentEncoding = Encoding.UTF8, ContentType = "application/json"};
            
            //Or show a View or redirect 
            return View();
            
            //Or show nothing 
            return return new EmptyResult();
    
            //It depends on your logic 
        }
