    private static bool SendSafeMessage(Recipients recipients, string[] addressListReplyTo, string subject, string body, string[] attachments, bool requestReadReceipt, Log log, bool isHtmlBody = false)
        {
            //This method was added because sometimes messages were getting stuck in the Outlook Outbox and this seems to solve that
            bool result = true;
            Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.NameSpace namespaceMAPI = application.GetNamespace("MAPI");
            namespaceMAPI.Logon();
            RDOSession session = null;
            session = GetSessionAndLogon(log); //TODO: I'm creating a 2nd session here which is wasteful
            SafeMailItem safeMail = Redemption.RedemptionLoader.new_SafeMailItem();
            Microsoft.Office.Interop.Outlook.MailItem outlookMailItem = (Microsoft.Office.Interop.Outlook.MailItem)application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            safeMail.Item = outlookMailItem;
            if (isHtmlBody)
                outlookMailItem.HTMLBody = body;
            else
                safeMail.Body = body;
            outlookMailItem.Subject = subject;
            outlookMailItem.ReadReceiptRequested = requestReadReceipt;
            foreach (string attachment in attachments)
            {
                if (attachment != "")
                    safeMail.Attachments.Add(attachment);
            }
            foreach (string address in addressListReplyTo)
            {
                if (address != "")
                    safeMail.ReplyRecipients.Add(address);
            }
            foreach (string address in recipients.To)
            {
                if (address != "")
                    safeMail.Recipients.Add(address).Type = 1;
            }
            foreach (string address in recipients.Cc)
            {
                if (address != "")
                    safeMail.Recipients.Add(address).Type = 2;
            }
            foreach (string address in recipients.Bcc)
            {
                if (address != "")
                    safeMail.Recipients.Add(address).Type = 3;
            }
            foreach (Microsoft.Office.Interop.Outlook.Recipient recipient in outlookMailItem.Recipients)
            {
                if (!OutlookMailEngine64.existsName(recipient.Name, session, log == null ? null : log))
                    result = false;
            }
            if (result)
            {
                try
                {
                    safeMail.Send();
                    result = true;
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    string message = "Error while sending email: " + ex.Message;
                    if (log != null)
                        log.Message(message);
                    if (OutlookMailEngine64.DiagnosticMode)
                        MessageBox.Show(message);
                    throw new EmailLibraryException(EmailLibraryException.ErrorType.InvalidRecipient, "One or more recipients are invalid (use OutlookMailEngine64.ValidateAddresses first)", ex);
                }
            }
            if (session.LoggedOn)
                session.Logoff();
            namespaceMAPI.Logoff();
            return result;
        }
