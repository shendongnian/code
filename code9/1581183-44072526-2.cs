    public FileResult ExportCsv()
        {
            var fileString = this.Session["fileString"].ToString();
            byte[] bytes = new byte[] { };
            bytes = Encoding.ASCII.GetBytes(fileString);
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "report.csv");
        }
