                    #region Create mail body using LinkedResource
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
               
                    doc.LoadHtml(mailBody);
                    var i = 1;
                    AlternateView htmlview = default(AlternateView);
                    var imageResourceList = new List<LinkedResource>();
                    if (doc.DocumentNode.SelectNodes("//img") != null)
                    {
                        foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//img"))
                        {
                            var base64String = img.GetAttributeValue("src", null);
                            base64String = base64String.Replace("data:image/png;base64,", "");
                            var bytes = Convert.FromBase64String(base64String);
                            var stream = new MemoryStream(bytes);
                            LinkedResource imageResourceEs = new LinkedResource(stream, MediaTypeNames.Image.Jpeg);
                            imageResourceEs.ContentId = "img" + i;
                            imageResourceEs.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                            imageResourceList.Add(imageResourceEs);
                            img.SetAttributeValue("src", "cid:img" + i);
                            i++;
                        }
                    }
                    htmlview = AlternateView.CreateAlternateViewFromString(doc.DocumentNode.OuterHtml, null, "text/html");
                    foreach (var imgSource in imageResourceList)
                    {
                        htmlview.LinkedResources.Add(imgSource);
                    }
                    #endregion
                    //split email address
                    var newIds = emailIds.Split(',');
                    //create new MailMessage object
                    var mail = new MailMessage { From = new MailAddress(emailTemplate.FromEmail, emailTemplate.FromText) };
                    //set email address of reciver to mail message 
                    foreach (var email in newIds)
                    {
                        mail.To.Add(email);
                    }
                    //set mail subject
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    //set mail body
                    mail.Body = doc.DocumentNode.OuterHtml;
                    //Add AlternateViews
                    mail.AlternateViews.Add(htmlview);
                 
                    //send mail 
                    SendEmail(mail);
