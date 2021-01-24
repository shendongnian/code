    lock (fileLock)
    {
      string stringpath = Path.Combine(@"C:\temps", clientid+".pdf";
      // If you need the streamwriter then uncomment the lines below
      // using (StreamWriter writer = new StreamWriter(stringpath))
      // { 
         report.ExportToDisk(CrystalDecisions.
                   Shared.ExportFormatType.PortableDocFormat, 
                   stringpath );
         report.Dispose();
    
         Attachment files = new Attachment(stringpath);
         Mailmsg.Attachments.Add(files);
      // end using
      // }
    }
