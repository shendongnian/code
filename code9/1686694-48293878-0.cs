    static void Main(string[] args)
            {
                string login = "lee@domain.onmicrosoft.com"; //give your username here  
    
                using (var context = new ClientContext("https://domain.sharepoint.com/sites/tst"))
                {
                    string password = "pw";
                    SecureString sec_pass = new SecureString();
                    Array.ForEach(password.ToArray(), sec_pass.AppendChar);
                    sec_pass.MakeReadOnly();
                    context.Credentials = new SharePointOnlineCredentials(login, sec_pass);
    
                    var path = "/sites/tst/mydoc3/beginning_sharepoint_2013_development.pdf";
                    var file = context.Web.GetFileByServerRelativeUrl(path);
                    context.Load(file);
                    context.ExecuteQuery();
    
                    ClientResult<System.IO.Stream> data = file.OpenBinaryStream();
                    context.Load(file);
                    context.ExecuteQuery();                
    
                    string textPDF = string.Empty;
                    using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
                    {
                        if (data != null)
                        {
                            data.Value.CopyTo(mStream);
                            byte[] array = mStream.ToArray();
                            PdfReader reader = new PdfReader(array);
    
                            for (int page = 1; page <= reader.NumberOfPages; page++)
                            {
                                textPDF += PdfTextExtractor.GetTextFromPage(reader, page);
                            }
    
                            reader.Close();
                        }
                    }
                }            
                Console.WriteLine("done");
                Console.ReadKey();
    
            }
