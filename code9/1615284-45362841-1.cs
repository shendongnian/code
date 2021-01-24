        public ActionResult Recover(string UserEmail)
        {
            Login model = new Login();
            MySqlConnection connect = DbConnection();
            MySqlCommand cmd = new MySqlCommand("Recover_PassWord",connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", UserEmail);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (UserEmail == rd["ContactEmail"].ToString())
                {
                    try
                    {
                        SmtpClient mySmtpClient = new SmtpClient("my.smtp.exampleserver.net");
                        // set smtp-client with basicAuthentication
                        mySmtpClient.UseDefaultCredentials = false;
                        System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("username", "password");
                        mySmtpClient.Credentials = basicAuthenticationInfo;                    
                        MailMessage msg = new MailMessage();
                        msg.To.Add(UserEmail);
                        msg.Subject = "Recovered Login Information";
                        msg.Body = "Hello," + Environment.NewLine + "Your Login Information: "; //this is where i want to be able to use the returned value
                        msg.Body += Environment.NewLine + "username:" + (string)rd["username"];
                        msg.Body += Environment.NewLine + "password:" + (string)rd["password"];          
                        mySmtpClient.Send(msg);
                    
                    }
                    catch (SmtpException ex)
                    {
                      throw new ApplicationException
                        ("SmtpException has occured: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                       throw ex;
                    }
                }
            }
            return null;
        }
