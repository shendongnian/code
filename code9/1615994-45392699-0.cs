    try
    {
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    
            	    SmtpClient smtp = new SmtpClient();
                    //smtp object.        
    		
    	            Msg.From = new MailAddress("from@gmail.com");
                    // Recipient e-mail address.
                    
                    Msg.To.Add(to@gmail.com);
    		        //here you can pass textbox value how need to send mail.
    
                    Msg.Subject = "Please confirm your subscription";
                    Msg.Body = "<body></body>";
    
    
                    Msg.IsBodyHtml = true;
                    // your remote SMTP server IP.
                    
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("from@gmail.com", "password");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                    //Msg = null;
    }
    catch(Exception ex)
    {
    	Message.Show("Error:" + ex.Message);
    }         
