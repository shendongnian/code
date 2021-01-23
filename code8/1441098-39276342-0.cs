    public void GetDocument(Guid UserId, string Filename)
    {
      string mimeType = "application/pdf"
      Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
      Response.WriteFile(fileName);
      Response.End();
    }
