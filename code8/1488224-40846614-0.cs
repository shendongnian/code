     Outlook.MailItem mail = null;
    Outlook.Recipients mailRecipients = null;
    Outlook.Recipient mailRecipient = null;
    try
    {
        mail = OutlookApp.CreateItem(Outlook.OlItemType.olMailItem)
           as Outlook.MailItem;
        mail.Subject = "A programatically generated e-mail";
        mailRecipients = mail.Recipients;
        mailRecipient = mailRecipients.Add("Eugene Astafiev");
        mailRecipient.Resolve();
        if (mailRecipient.Resolved)
        {
            mail.Send();
        }
        else
        {
            System.Windows.Forms.MessageBox.Show(
                "There is no such record in your address book.");
        }
    }
    catch (Exception ex)
    {
        System.Windows.Forms.MessageBox.Show(ex.Message,
            "An exception is occured in the code of add-in.");
    }
    finally
    {
        if (mailRecipient != null) Marshal.ReleaseComObject(mailRecipient);
        if (mailRecipients != null) Marshal.ReleaseComObject(mailRecipients);
        if (mail != null) Marshal.ReleaseComObject(mail);
    }
