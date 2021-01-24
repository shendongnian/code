     [HttpPost]        
     public HttpResponseMessage UploadJsonFile()
     {        
                    userID = "any name";    
                        HttpResponseMessage response = new HttpResponseMessage();
                        var httpRequest = HttpContext.Current.Request;
                        if (httpRequest.Files.Count > 0)
                        {
                            foreach (string file in httpRequest.Files)
                            {
                                try
                                {
                                    var postedFile = httpRequest.Files[file];
                                    var filePath = HttpContext.Current.Server.MapPath("~/ProfileImages/"+ userID);
                                    if (!Directory.Exists(filePath))
                                    {
                                        Directory.CreateDirectory(filePath);
                                    }
                                    else
                                    {
                                        DirectoryInfo directory = new DirectoryInfo(filePath);
                                        FileInfo[] files = directory.GetFiles("*.jpg");
                                        foreach (FileInfo fil in directory.GetFiles())
                                        {
                                            fil.Delete(); //Delete existing image...
                                        }
                                    }
                                    Random rnd = new Random();
                                    int num = rnd.Next(1, 100);
                                    postedFile.SaveAs(filePath +"/"+ num+postedFile.FileName);
                                }
                                catch (Exception e)
                                {
                                    ExceptionLogging.SendErrorToText(e);
                                }
                            }
                        }
                        return response;
                    }
