        static void Main(string[] args)
        {
                Outlook.Application tmpOutlookApp = new Outlook.Application();
                Outlook.MailItem tmpMessage = (Outlook.MailItem)tmpOutlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                tmpMessage.HTMLBody = "Test";
                String sDisplayName = "Test";
                int iPosition = (int)tmpMessage.Body.Length + 1;
                int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                Outlook.Attachment oAttach = tmpMessage.Attachments.Add(@"C:\Test.txt", iAttachType, iPosition, sDisplayName);
                tmpMessage.Subject = "Your Subject will go here.";
                Outlook.Recipients oRecips = (Outlook.Recipients)tmpMessage.Recipients;
                Outlook.Recipient tmpRecipient = (Outlook.Recipient)oRecips.Add("EMail");
                tmpRecipient.Resolve();
                tmpMessage.Send();
        }
