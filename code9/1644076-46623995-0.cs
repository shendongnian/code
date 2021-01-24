    public class MyMail
    {
        private const double WaitingForSending = 30.0;
        #region Local variables
        public bool SSL_Encryption = true;
        public System.Collections.Generic.List<System.Net.Mail.MailAddress> Address = null;
        public System.Collections.Generic.List<System.Net.Mail.MailAddress> CC = null;
        public System.Collections.Generic.List<System.Net.Mail.MailAddress> BCC = null;
        public System.Collections.Generic.List<string> AttachmentFileName = null;
        public string Body = "";
        public string Subject = "";
        #endregion
  
        private Microsoft.Office.Interop.Outlook.Application OL;
        private Microsoft.Office.Interop.Outlook.MailItem Mail;
        public void SendMail()
        {
            double Waited = .0;
            string fAddress = string.Empty;
            
            if (this.Address == null) { return; }
            OL = new Microsoft.Office.Interop.Outlook.Application();
            
            Mail = (Microsoft.Office.Interop.Outlook.MailItem)OL.CreateItem(OlItemType.olMailItem);
            Mail.Subject = this.Subject;
            if (this.Address != null) { foreach (System.Net.Mail.MailAddress MA in this.Address) { fAddress += MA.Address + "; "; } Mail.To = fAddress; fAddress = string.Empty; }
            if (this.CC != null) { foreach (System.Net.Mail.MailAddress MA in this.CC) { fAddress += MA.Address + "; "; } Mail.CC = fAddress; fAddress = string.Empty; }
            if (this.BCC != null) { foreach (System.Net.Mail.MailAddress MA in this.BCC) { fAddress += MA.Address + "; "; } Mail.BCC = fAddress; fAddress = string.Empty; }
            Mail.Body = this.Body;
            if (this.AttachmentFileName != null) { foreach (string Att in this.AttachmentFileName) { if (System.IO.File.Exists(Att)) { Mail.Attachments.Add(Att, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing); } } }
            // the following method is not required for sending emails
            // Mail.Display(false);
            try
            {
                Mail.Send();
            } catch (System.Exception ex) { throw ex; }           
        }
    }
