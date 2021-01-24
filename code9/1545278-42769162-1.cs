      public ActionResult SendEmail(SmartSolutions.Models.InvitationMail _objModelMail)
        {
             
             if (ModelState.IsValid)
            {
                var emailList = db.InvitationMails.Select(model => model.To);
                var emailList2 = db.InvitationMails.Select(model => model.Link);
                var link2 = emailList2.FirstOrDefault();
                var emails = String.Join(",", emailList);
                MailMessage mail = new MailMessage();
                mail.To.Add(emails);
                mail.From = new MailAddress(_objModelMail.From = "suhomlin.eugene93@gmail.com");
                mail.Subject = _objModelMail.Subject = "Видео интервью";
               
                string Body = _objModelMail.Body= "Предлагаем пройти интервью"+ link2;
                
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("suhomlin.eugene93@gmail.com", "********");// Enter senders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("SendEmail", _objModelMail as IEnumerable<InvitationMail>);
            }
             else
             {
                 return View();
             }
        }
