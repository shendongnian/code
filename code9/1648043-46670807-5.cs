    public IEnumerable<EmailInfo> infosFromXml(string path)
    {
        // Same as before ...
        foreach (var r in photo_information)
        {
            if (r.user_data != "")
            {
                ...
                yield return new EmailInfo{
                          Data=r.user_data, 
                          Attachment=attachmentFilename};
            }
           ...
        }
    }
