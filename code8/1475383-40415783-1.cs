    public ActionResult DownloadFile(int id)
     {
      MemoryStream workStream = new MemoryStream();
      DataModel DB = new DataModel();
      var content = DB._PATIENT.Where(m => m.ID == id).FirstOrDefault();
      byte[] contents = (byte[])content.Result;
      workStream.Write(contents, 0, contents.Length);
      workStream.Position = 0;
    
      Response.AddHeader("Content-Disposition", "inline; filename=someFile.pdf");
      return File(workStream, "application/pdf", "someFile.pdf");
    }
