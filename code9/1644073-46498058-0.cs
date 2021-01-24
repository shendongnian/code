        public void SendMail()
        {
            double Waited = .0;
            bool StillRunning = false; //new
            string fAddress = string.Empty;
            
            if (this.Address == null) { return; }
            Microsoft.Office.Interop.Outlook.Application OL = Daimler.JS.Office.Outlook.GetOutlook(out StillRunning); //new
            Microsoft.Office.Interop.Outlook.MailItem Mail = (Microsoft.Office.Interop.Outlook.MailItem)OL.CreateItem(OlItemType.olMailItem);
            Mail.Subject = this.Subject;
            if (this.Address != null) { foreach (System.Net.Mail.MailAddress MA in this.Address) { fAddress += MA.Address + "; "; } Mail.To = fAddress; fAddress = string.Empty; }
            if (this.CC != null) { foreach (System.Net.Mail.MailAddress MA in this.CC) { fAddress += MA.Address + "; "; } Mail.CC = fAddress; fAddress = string.Empty; }
            if (this.BCC != null) { foreach (System.Net.Mail.MailAddress MA in this.BCC) { fAddress += MA.Address + "; "; } Mail.BCC = fAddress; fAddress = string.Empty; }
            Mail.Body = this.Body;
            if (this.AttachmentFileName != null) { foreach (string Att in this.AttachmentFileName) { if (System.IO.File.Exists(Att)) { Mail.Attachments.Add(Att, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing); } } }
            Mail.Display(false);
            Microsoft.Office.Interop.Outlook.Inspector INP = Mail.GetInspector; //new
            try
            {
                Mail.Send();
            } catch (System.Exception ex) { throw ex; }
            while(!Mail.Sent && Waited < 30.0) { System.Threading.Thread.Sleep(500); Waited += 0.5; }
            INP = null; //new
            if (!StillRunning) { OL.Quit(); } //new
        }
        public static Microsoft.Office.Interop.Outlook.Application GetOutlook(out bool StillRunning)
        {
            Microsoft.Office.Interop.Outlook.Application OLApp = null;
            // Check whether there is an Outlook process running.
            if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Count() > 0)
            {
                // If so, use the GetActiveObject method to obtain the process and cast it to an Application object.
                StillRunning = true;
                return System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application") as Microsoft.Office.Interop.Outlook.Application;
            }
            else
            {
                StillRunning = false;
                // If not, create a new instance of Outlook and log on to the default profile.
                OLApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.NameSpace nameSpace = OLApp.GetNamespace("MAPI");
                nameSpace.Logon("", "", System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                nameSpace = null;
                return OLApp;
            }
        }
