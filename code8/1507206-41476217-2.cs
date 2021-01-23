    private TextExtractor _textExtractor;
    private string _attachmentTextFilepath = @"c:\temp\EmailAttachmentText.txt";
    static void IterateMessages(Outlook.Folder folder)
    {
        var fi = folder.Items;
        if (fi != null)
        {
            foreach (Object item in fi)
            {
                Outlook.MailItem mi = (Outlook.MailItem)item;
                var attachments = mi.Attachments;
                if (attachments.Count != 0)
                {
                    for (int i = 1; i <= mi.Attachments.Count; i++)
                    {
                         //Save email attachments
                         mi.Attachments[i].SaveAsFile(@"C:\temp\" + mi.Attachments[i].FileName);
                         //Use TIKA to read the contents of the file
                         TextExtractionResult textExtractionResult = _textExtractor.Extract(@"C:\temp\" + mi.Attachments[i].FileName);
                         
                        //Save attachment text to a txt file
                        File.AppendAllText(_attachmentTextFilepath, textExtractionResult.Text);
                    }
                }
            }
        }
    }
