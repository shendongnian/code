      private static string GetMimeType(string fileName)
            {
                string mimeType = "application/unknown";
                string ext = System.IO.Path.GetExtension(fileName).ToLower();
                Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
                if (regKey != null && regKey.GetValue("Content Type") != null)
                    mimeType = regKey.GetValue("Content Type").ToString();
                return mimeType;
            }        
    
            public static Google.Apis.Drive.v3.Data.File uploadFile(Google.Apis.Drive.v3.DriveService service, string uploadFile, string[] parents)
            {
                if (System.IO.File.Exists(uploadFile))
                {
                    var body = new Google.Apis.Drive.v3.Data.File();
                    body.Name = System.IO.Path.GetFileName(uploadFile);
                    body.Description = "File uploaded by Diamto Drive Sample";
                    body.MimeType = GetMimeType(uploadFile);
                    body.Parents = parents;
    
                    // File's content.
                    byte[] byteArray = System.IO.File.ReadAllBytes(uploadFile);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                    try
                    {
                        var request = service.Files.Create(body, stream, GetMimeType(uploadFile));
                        request.Upload();
                        return request.ResponseBody;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message); return null;
                    }
                }
                else { Console.WriteLine("File does not exist: " + uploadFile); return null; }
            }
