    public virtual void Send(string body, string attachment)
        {
            var message = new MimeMessage();
            message.From.Add(GetFromAddress());
            message.To.AddRange(GetToAddresses());
            message.Subject = "Kiosk error";
            message.Body = CreateBody(body, attachment);
            using (var SmtpClient = new SmtpClient())
            {
                try
                {
                    if (!SmtpClient.IsConnected)
                    {
                        ConnectToGmail(SmtpClient);
                    }
                    SmtpClient.Send(message);
                    SmtpClient.Disconnect(true);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                }
            }
        }
