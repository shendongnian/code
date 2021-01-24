                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mymail@mail.com"); 
				
                    mail.To.Add("anymail@mail.com"); 
					
                    mail.To.Add(empfaenger.Text);
                
                    mail.Subject = "Betreff Text";
                
                    mail.Body = "body Text";
                
                SmtpClient client = new SmtpClient("smtp", "port");
                client.UseDefaultCredentials = false;
				
                try
                {
                    client.Credentials = new System.Net.NetworkCredential("mymail@mail.com", "anymail@mail.com");
                    client.EnableSsl = true;
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    //If not than......
                }
