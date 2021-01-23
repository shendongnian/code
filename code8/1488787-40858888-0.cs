    foreach (Attachment atch in rptOutputResponse.Response.attachments)
    {
        RptAttachmentsBuffer.AddRow();
        RptAttachmentsBuffer.AppId = rptOutputResponse.Response.appId;
        RptAttachmentsBuffer.Type = atch.type;
        RptAttachmentsBuffer.Name = atch.name;
        RptAttachmentsBuffer.ContentType = atch.contentType;
        string json = Encoding.UTF8.GetString(Convert.FromBase64String(atch.content));
        System.Windows.Forms.MessageBox.Show(json);
        RptAttachmentsBuffer.ReportContent.AddBlobData(newbytes);
    }
