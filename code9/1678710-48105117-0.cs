    IUserMailFoldersCollectionPage allMailFolders = await graphClient.Users[inbox].MailFolders.Request().GetAsync();
            foreach(MailFolder folder in allMailFolders)
            {
                if (folder.DisplayName == "01 Processed")
                {
                    processedFolder = folder.Id;
                }
                if (folder.DisplayName == "02 Needs Attention")
                {
                    needsAttentionFolder = folder.Id;
                }
            }
     if (needsAttention)
                    {
                        needsAttentionCount++;
                        Message movedMsg = await graphClient.Users[inbox].Messages[message.Id].Move(needsAttentionFolder).Request().PostAsync(); 
                    }
                   else
                    {
                         Message movedMsg = await graphClient.Users[inbox].Messages[message.Id].Move(processedFolder).Request().PostAsync();
                    }
