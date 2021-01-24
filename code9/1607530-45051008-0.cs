    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      string filePath = "~/Data/Book1.csv";
      System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(filePath));
      if (file.Exists)
      {
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.AddHeader("Content-Disposition", "Attachment;Filename=" + file.Name);
        response.TransmitFile(file.FullName);
        response.Flush();
        response.End();   
      }
    }
