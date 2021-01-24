        string baseImageLocation = HttpContext.Current.Server.MapPath("~/Admin/imgs/");
        
        HttpPostedFile Files;
        Files = context.Request.Files[0]; // Load File collection into HttpFileCollection variable.
        //Files.ContentLength;
        //Files.ContentType;
        if (Files != null && Files.ContentLength > 0)
        {
            System.IO.Stream fileStream = Files.InputStream;
            fileStream.Position = 0;
            byte[] fileContents = new byte[Files.ContentLength];
            fileStream.Read(fileContents, 0, Files.ContentLength);
            string fileExt = System.IO.Path.GetExtension(Files.FileName).ToLower();
            string fileName = Path.GetFileName(Files.FileName);
            System.Drawing.Image image = null;
            if (fileName != null)
            {
                if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".jpg" || fileExt == ".png" || fileExt == ".jpeg")
                {
                    image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(fileContents));
                    if (System.IO.File.Exists(baseImageLocation + "/" + fileName))
                        fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExt;
                    Files.SaveAs(baseImageLocation + fileName);
                }
            }
            string link = VirtualPathUtility.ToAbsolute("~/Admin/imgs/") + fileName;
            
            string imageHeight = image.Height.ToString();
            string imageWidth = image.Width.ToString();
            string json = "";
            json += "{" +
                    "\"links\": \"" + link + "\"," +
                    "\"width\": \"" + imageWidth + "\"," +
                    "\"height\": \"" + imageHeight + "\"" +
                    "}";
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }
    
