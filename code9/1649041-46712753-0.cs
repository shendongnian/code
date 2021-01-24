    class Program
        {
            static void Main(string[] args)
            {            
                const string fileToConvert = @"C:\Projects\_temp\test1.docx";
                const string fileToSave = @"C:\Projects\_temp\test1.pdf";            
    
                try
                {
                    using (var client = new WebClient())
                    {
                        client.Headers.Add("accept", "application/octet-stream");
                        var resultFile = client.UploadFile(new Uri("https://v2.convertapi.com/docx/to/pdf?Secret=xxxxx"), fileToConvert); 
                        File.WriteAllBytes(fileToSave, resultFile );
                        Console.WriteLine("File converted successfully");
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                    Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                    Console.WriteLine("Body : {0}", new StreamReader(e.Response.GetResponseStream()).ReadToEnd());
                }
                
                Console.ReadLine();
            }
        }
