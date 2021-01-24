           [HttpGet]
            public ActionResult ContactMail()
            {
    
    
                return View();
            }
    
            [HttpPost]
            public ActionResult ContactMail(SampleMail sm)
            {
                SmtpClient MailClient = new SmtpClient();
            MailClient.Host = "Server Name";// smtp server name which you are going to use
            MailClient.Port = 25; // port number
            MailClient.Credentials=new System.Net.NetworkCredential("yourusername", "yourpassword");
            MailMessage msg = new MailMessage();
            msg.Body = sm.Message + "</br> By" + sm.Name;
            msg.To.Add(new MailAddress("xyz@gmail.com ")); // change the mail with your email address
            msg.IsBodyHtml = true;
           
            MailClient.Send(msg);
    
                return View();
            }
