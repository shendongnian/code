        System.Net.Mail.AlternateView htmlView = null;
            string from = "xxx@outlook.com";
            using (MailMessage mail = new MailMessage(from, txtEmail.Text.Trim()))
            {
                mail.Subject = "Json File";
                htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString("<html><body><div style='border-style:solid;border-width:5px;border-radius: 10px; padding-left: 10px;margin: 20px; font-size: 18px;'> <p style='font-family: Vladimir Script;font-weight: bold; color: #f7d722;font-size: 48px;'>Kindly find the Attachment.</p><hr><div width=40%;> <p  style='font-size: 20px;'>Thanks</div></body></html>", null, "text/html");
                mail.AlternateViews.Add(htmlView);
                mail.IsBodyHtml = true;
                System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
                contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
                contentType.Name = "New-Assign04.json";
                mail.Attachments.Add(new Attachment(Server.MapPath("~/App_Data/New-Assign04.json"), contentType));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential("xxx@outlook.com", "xxxxxxxx");   // username and password
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
			}
