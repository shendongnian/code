            if (Session["ExtractNo"].ToString() == "Extract 1")
            {
                //Email Config
                const string username = "roll@test.ac.uk"; //account address
                const string password = "######"; //account password
                
                SmtpClient smtpclient = new SmtpClient();
                smtpclient.Host = "omavex011";  
                smtpclient.Port = 25; 
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpclient.Credentials = new System.Net.NetworkCredential(username, password);
                   
                string SendEmail = ConfigurationManager.ConnectionStrings["Sendmail"].ConnectionString;
                    
                SqlDataReader reader;
                String SendMessage = "SELECT Name, Position, Email FROM AuthorisedStaff Where Position = 'CM' or Position = 'DHOD' or Position = 'HOD'"; //<---- change position before launch
                        
                using (SqlConnection myConnection = new SqlConnection(SendEmail))
                {
                   myConnection.Open();
                   SqlCommand myCommand = new SqlCommand(SendMessage, myConnection);
                        
                   ArrayList emailArray = new ArrayList();
                   reader = myCommand.ExecuteReader();
                        
                   var emails = new List<EmailCode>();
                        
                   while (reader.Read())
                   {
                      emails.Add(new EmailCode { Email = Convert.ToString(reader["Email"]),
                                                 Name = Convert.ToString(reader["Name"]),
                                                 Position = Convert.ToString(reader["Position"])
                                                });
                                               }
                        
                     foreach (EmailCode email in emails)
                     {
                        
                       MailMessage mail = new MailMessage();
                       MailAddress fromaddress = new MailAddress("roll@test.ac.uk", "PTLP"); //address and from name
                        
                       mail.From = fromaddress;
                       mail.To.Add(email.Email);
                       mail.Subject = ("PTLP Check");
                       mail.IsBodyHtml = true;
                       mail.Body = HttpUtility.HtmlEncode(email.Name) + " <br /> <p>Part Time Payroll details are now available for checking.</p> ";
                        smtpclient.Send(mail);
                  }
                 }
                 smtpclient.Dispose();
                }
