    public FileResult GetBytes()
    {
       string path = Server.MapPath("~/Files/PDFIcon.pdf");
       byte[] mas = System.IO.File.ReadAllBytes(path);
       string file_type = "application/pdf";
       string file_name = "PDFIcon.pdf";
       return File(mas, file_type, file_name);
    }
