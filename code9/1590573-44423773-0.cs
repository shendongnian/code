        public static void Main(string[] args)
        {
            CreateMails(new List<string>() {"emailaddresshere"});
            Console.WriteLine("finished");
            Console.ReadLine();
        }
        public static void CreateMails(List<string> recipients)
        {
            Microsoft.Office.Interop.Outlook.Application outlook = new Microsoft.Office.Interop.Outlook.Application();
            foreach (string recipient in recipients)
            {
                MailItem mail = outlook.CreateItem(OlItemType.olMailItem);
                mail.SentOnBehalfOfName = "Sending User";
                mail.BCC = recipient;
                mail.Subject = "TEST";
                mail.BodyFormat = OlBodyFormat.olFormatPlain;
                mail.HTMLBody = "Hello";
                mail.Send();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(mail); // key change
            }
            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            outlook.Application.Quit();
            outlook.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(outlook); // key change
            outlook = null;
            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
