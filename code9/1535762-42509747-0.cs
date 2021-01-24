          [HttpPost]
        public ActionResult SendWebPageAsAttachment()
        {
            var subject = Request.Form["subject"]; // You can provide subject from page or code
            var mailContent = Request.Form["bodyInnerHTML"]; // get the body inner HTML by form name
            var Body = "<div style='background-color:white;'>" +  Request.Form["mailContent"] + "</div>"; // Email Body
            var attachmentName = DateTime.Now.ToString("yyyy/MM/dd").Replace("/", "-") + "_" + 
                DateTime.Now.ToLongTimeString().Replace(" ", "_") + ".html"; // Attachment Name
            var baseUrl = HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Authority + 
                HttpContext.Request.ApplicationPath.TrimEnd('/') + '/'; // Base URL
            string src = @"src=""";
            mailContent = mailContent.Replace(src, src + baseUrl.Remove(baseUrl.Length - 1));
            mailContent = "<html><head><link href='" + baseUrl + "Themes/styles.css' rel='stylesheet' type='text/css' /><link href='" + 
                baseUrl + "Themes/style.css' rel='stylesheet' type='text/css' /></head><body>" + WebUtility.HtmlDecode(mailContent) + 
                "</body></html>";
            try
            {
                SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);
                smtpClient.Credentials = new System.Net.NetworkCredential("info@MyWebsiteDomainName.com", "myIDPassword");
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();
                //Setting From , To and CC
                mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
                mail.To.Add(new MailAddress("info@MyWebsiteDomainName"));
                mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));
                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = Body;
                var mailDataBytes = ASCIIEncoding.Default.GetBytes(mailContent);
                var mailStream = new MemoryStream(mailDataBytes);
                mail.Attachments.Add(new Attachment(mailStream, attachmentName));
                smtpClient.Send(mail);  
            }
            catch (Exception ex)
            {
                //catch
            }
            ViewBag.IsHttpPost = true;
            return View("SendWebPageAsAttachment");
        }
