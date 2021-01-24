        public static class MAPIOutlook
    {
        public static OL.Application GetOutlook(out bool StillRunning)
        {
            OL.Application OLApp = null;
            OL.NameSpace nameSpace = null;
            if (System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Count() > 0)
            {
                StillRunning = true;
                try
                {
                    OLApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application") as Microsoft.Office.Interop.Outlook.Application;
                }
                catch {
                    KillOutlook();
                    OLApp = new OL.Application();
                    nameSpace = OLApp.GetNamespace("MAPI");
                    nameSpace.Logon("", "", System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                }
            }
            else
            {
                StillRunning = false;
                OLApp = new OL.Application();
                nameSpace = OLApp.GetNamespace("MAPI");
                nameSpace.Logon("", "", System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            }
            return OLApp;
        }
        public static void KillOutlook()
        {
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("OUTLOOK")) { p.Kill(); }
        }
        public static void SendMailAdv(string[] To, string[] CC, string[] BCC, string Subject, string Body, string[] Attachment)
        {
            bool StillRunning = false;
            OL.Application OlApp = GetOutlook(out StillRunning);
            OL.NameSpace NS = OlApp.GetNamespace("MAPI");
            OL.MAPIFolder MFold = NS.GetDefaultFolder(OL.OlDefaultFolders.olFolderOutbox);
            OL.MailItem MI = (OL.MailItem)OlApp.CreateItem(OL.OlItemType.olMailItem);
            OL.Recipients oReci = MI.Recipients;
            
            foreach(string str in To)
            {
                OL.Recipient Rec = MI.Recipients.Add(str);
                Rec.Type = (int)OL.OlMailRecipientType.olTo;
            }
            foreach (string str in CC)
            {
                OL.Recipient Rec = MI.Recipients.Add(str);
                Rec.Type = (int)OL.OlMailRecipientType.olCC;
            }
            foreach (string str in To)
            {
                OL.Recipient Rec = MI.Recipients.Add(str);
                Rec.Type = (int)OL.OlMailRecipientType.olBCC;
            }
            MI.Subject = Subject;
            MI.Body = Body;
            foreach(string str in Attachment)
            {
                if (System.IO.File.Exists(str.Trim()))
                {
                    MI.Attachments.Add(str.Trim(), OL.OlAttachmentType.olByValue, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                }
            }
            int nOutItems = MFold.Items.Count;
            MI.Send();
            while(nOutItems != MFold.Items.Count)
            {
                System.Threading.Thread.Sleep(250);
            }
            if (!StillRunning)
            {
                OlApp.Application.Quit();
                OlApp.Quit();
                KillOutlook();
            }
        }
    }
