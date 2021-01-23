     if (obj.Design != null)
     {
         var stream = obj.Design.InputStream;
         stream.Seek(0, SeekOrigin.Begin);
         message.Attachments.Add(new Attachment(stream, Path.GetFileName(obj.Design.FileName)));
     }
