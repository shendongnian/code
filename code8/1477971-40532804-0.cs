    private void button1_Click_1(object sender, EventArgs e)
    {
        {
            cryRpt = new ReportDocument();
            cryRpt.Load("CrystalReport1.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
        try
        {
            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = pdfFile;
            CrExportOptions = cryRpt.ExportOptions;
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrFormatTypeOptions;
            cryRpt.Export();
            sendmail();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
    private void sendmail()
    {
        Outlook.Application app = null;
        if (Process.GetProcessesByName("OUTLOOK").Length > 0)
        {
            app = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
        }
        else
        {
            app = new Outlook.Application();
        }
        try
        {
    //In case of Outlook
            Outlook.TaskItem tsk = (Outlook.TaskItem)app.CreateItem(Outlook.OlItemType.olTaskItem);
            Outlook.MailItem mail = app.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;
            Outlook.AddressEntry currentUser = app.Session.CurrentUser.AddressEntry;
            mail.Attachments.Add(pdfFile);
            mail.Subject = "This is the subject";
            mail.To = "destination@email.com";
            mail.Body = "mail with attachment";
            mail.Importance = Outlook.OlImportance.olImportanceHigh;
            mail.Display(false);
            mail.Send();
    //In case of smtp - This bit is a bit more temperamental. Suggestions for improvement are welcome.
            MailMessage mail = new MailMessage();
            mail.Subject = "This is the subject";
            mail.From = new MailAddress(UserPrincipal.Current.EmailAddress);
            mail.To = "destination@email.com";
            mail.Body = "mail with attachment";
            Attachment attachment;
            attachment = new Attachment(pdfFile);
            mail.Attachments.Add(attachment);
            SmtpClient SmtpServer = new SmtpClient
            {
                "smtp.office365.com",
                Host = "outlook.office365.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("user@email.com", "Password")
                Credentials = CredentialCache.DefaultNetworkCredentials
                };
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
        public static Microsoft.Office.Interop.Outlook.Application GetActiveOutlookApplication()
        {
            return (Microsoft.Office.Interop.Outlook.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application");
        }
