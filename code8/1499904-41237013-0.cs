     public ResponseDto sendEmail(EmailDto emailDto) {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();
                message.From = new MailAddress("mail@gmail.com");
               message.Subject = "have a new mail";
            message.Body = "info: \n "
                + "name: " + emailDto.Name 
                + "\mail: "+ emailDto.Email + "\nMessage: " +
                emailDto.Message;
                message.To.Add("mail@hotmail.com");
                 client.EnableSsl = false;
                 client.UseDefaultCredentials = false;
                 client.Port = 25;
                 client.Host = "relay-hosting.secureserver.net";
                 client.Send(message);
            }
            catch (Exception e) {
                return new ResponseDto
                {
                    message = e.ToString()
                  ,
                    Success = false
                };
            }
            return new ResponseDto
            {
                message = "success",
                Success = true
            };
        }
