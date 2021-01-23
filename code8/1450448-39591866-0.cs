    using (System.Net.Mail.Attachment data = new System.Net.Mail.Attachment(HttpContext.Current.Server.MapPath(bytes)))
                {
                    mm.Attachments.Add(data);
                    ...
                }
