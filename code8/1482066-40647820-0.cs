    Try this code after  **smtp.EnableSsl = true;**
    string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
      + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
      + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            Regex ex = new Regex(validEmailPattern, RegexOptions.IgnoreCase);
            if (ex.IsMatch(TextBox1.Text))
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "kennethmontealto91@gmail.com",
                    Password = "********"
                };
                smtp.EnableSsl = true;
				
				MailMessage m = new MailMessage();
                m.From = new MailAddress("kennethmontealto91@gmail.com");
                m.To.Add(new MailAddress("kennethmontealto91@gmail.com"));
                m.Subject = "Try";
                m.Body = "TEST";
				
                smtp.Send(m);
			}
