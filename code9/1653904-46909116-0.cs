    private FileResult ViewFile(string[] Name)
            {
             //create your file at filePath
               byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
               return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "MyFile.pdf"));
            }
