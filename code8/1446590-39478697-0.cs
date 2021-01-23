    Using System.Net.Mail
    protected void SendMail()
    {     
        //Mail notification
        MailMessage message = new MailMessage();
        message.Subject = "Email Subject ";
        message.Body = "Email Message";
        message.From = new MailAddress("MyEmail@mail.com");
        // Email Address from where you send the mail
        var fromAddress = "MyEmail@mail.com";
        //Password of your mail address
        const string fromPassword = "password";
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
        smtp.Host = "smtp.mail.com";
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
        smtp.Timeout = 20000;
        }
        SqlCommand cmd = null;
        string connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        string queryString = @"SELECT EMAIL_ADDRESS FROM EMAIL WHERE EMAIL_ADDRESS = EMAIL_ADDRESS";
        using (SqlConnection connection =
                   new SqlConnection(connectionString))
        {
            SqlCommand command =
                new SqlCommand(queryString, connection);
            connection.Open();
            cmd = new SqlCommand(queryString);
            cmd.Connection = connection;
            SqlDataReader reader = cmd.ExecuteReader();
            // Call Read before accessing data.
            while (reader.Read())
            {
                var to = new MailAddress(reader["EMAIL_ADDRESS"].ToString());
                message.To.Add(to);
            }
            // Passing values to smtp object        
            smtp.Send(message);
            // Call Close when done reading.
            reader.Close();
        }
    }
