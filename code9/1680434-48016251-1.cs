     public FileResult Download()
        {
            String path = HostingEnvironment.ApplicationPhysicalPath + "Image\\Capture.PNG";
            string fname= Path.GetFileName(path);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            string fileName = fname;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    
        }
