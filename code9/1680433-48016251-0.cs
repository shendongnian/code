    public FileResult Download()
            {
                String path = HostingEnvironment.ApplicationPhysicalPath + "Image\\Capture.PNG";
              
                byte[] fileBytes = System.IO.File.ReadAllBytes(path);
                string fileName = "Capture.PNG";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    
            }
