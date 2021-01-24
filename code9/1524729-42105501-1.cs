           public void videoStream(string filePath)
        {
            //The header information 
            HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=Training.mp4");
            var file = new FileInfo(filePath);
            //Check the file exist,  it will be written into the response 
            if (file.Exists)
            {
                var stream = file.OpenRead();
                var bytesinfile = new byte[stream.Length];
                stream.Read(bytesinfile, 0, (int)file.Length);
                HttpContext.Response.BinaryWrite(bytesinfile);
            }
           
        }
           
