            try
            {
                LogHelper.LogMessage("<----- GetAttachmentsFromEmail Start ----->");
             
                // Bind to an existing message item and retrieve the attachments collection.
                // This method results in an GetItem call to EWS.
                EmailMessage message = EmailMessage.Bind(service, itemId, new PropertySet(ItemSchema.Attachments));
                List<ResponseMessage> ObjResponseMessage = new List<ResponseMessage>();
                // Iterate through the attachments collection and load each attachment.
                foreach (Attachment attachment in message.Attachments)
                {
                    if (attachment is FileAttachment)
                    {
                        FileAttachment fileAttachment = attachment as FileAttachment;
                        // Load the attachment into a file.
                        // This call results in a GetAttachment call to EWS.
                        fileAttachment.Load(StoreFilePath + fileAttachment.Name);
                        string FileName = fileAttachment.Name;
                    
                        LogHelper.LogMessage("OutLookMailStart In attachments File Name :" + FileName );
                        Console.WriteLine("File attachment name: " + fileAttachment.Name);
                    }
                    else // Attachment is an item attachment.
                    {
                        ItemAttachment itemAttachment = attachment as ItemAttachment;
                        // Load attachment into memory and write out the subject.
                        // This does not save the file like it does with a file attachment.
                        // This call results in a GetAttachment call to EWS.
                        itemAttachment.Load();
                        Console.WriteLine("Item attachment name: " + itemAttachment.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogError("OutLookMailStart -> GetAttachmentsFromEmail Exception");
                LogHelper.LogError("Exception Message :" + ex.Message);
                if (ex.InnerException != null)
                {
                    LogHelper.LogError("Exception InnerException :" + ex.InnerException);
                }
                LogHelper.LogError("Exception StackTrace :" + ex.StackTrace);
                LogHelper.LogError("OutLookMailStart -> GetAttachmentsFromEmail Exception"); ;
            }
            LogHelper.LogMessage("<----- GetAttachmentsFromEmail End ----->");
          
        }
