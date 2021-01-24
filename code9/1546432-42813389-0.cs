        public void DownloadTest()
        {
            var filePath = @"c:\code\testFile.txt";
            var reader = new StreamReader(filePath);
            var data = reader.ReadToEnd();
            var dataBinary = System.Text.Encoding.UTF8.GetBytes(data);
            Response.ContentType = "text/plain";
            Response.AddHeader("content-disposition", "attachment; filename=data.txt");
            Response.BinaryWrite(dataBinary);
        }
