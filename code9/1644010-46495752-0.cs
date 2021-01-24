           string username = string.Empty;
            string password = string.Empty;
            SqlConnection con = new SqlConnection(@"Data Source 
    (LocalDB)\v11.0;AttachDbFilename=C:\Users\SHEHAB\Documents\Visual Studio 2013\WebSites\password\App_Data\LoginDB.mdf;Integrated Security=True")
        using (SqlCommand cmd = new SqlCommand("SELECT Username, [Password] FROM  Users WHERE Email = @Email"))
            {
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        username = sdr["Username"].ToString();
                        password = sdr["Password"].ToString();
                    }
                }
                con.Close();
            }
            if (!string.IsNullOrEmpty(password))
            {
                var fromAddress = new MailAddress("from@gmail.com", "From Name");
                var toAddress = new MailAddress("to@example.com", "To Name");
                const string fromPassword = "fromPassword";
                const string subject = "Subject";
                const string body = string.Format("Hi {0},<br /><br />Your password is {1}.< br />< br /> Thank You.", username, password);
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = body
                })
                {
                    smtp.Send(message);
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Password has been sent to your email address.";
                }
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "This email address does not match our records.";
            }
