       var attachments = (from a in cc.CRMContext.ActivityMimeAttachments where a.ActivityId == email.ActivityId select a).ToList();
                    foreach (var attachment in attachments)
                    {
                        byte[] byteArray = Convert.FromBase64String(attachment.Body);
                        System.IO.File.WriteAllBytes(@"E:\test\temp\" + attachment.FileName, byteArray);
                    }
