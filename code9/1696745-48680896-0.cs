    using System;
    using System.Net;
    using System.IO;
    
    class MainClass {
      public static void Main (string[] args) {
                const string fileToConvert = "test.docx";
                const string fileToSave = "test.pdf";           
                const string Secret="";
    
                if (string.IsNullOrEmpty(Secret))
                  Console.WriteLine("The secret is missing, get one for free at https://www.convertapi.com/a");
                else
                  try
                  {
                      Console.WriteLine("Please wait, converting!");
                      using (var client = new WebClient())
                      {
                          client.Headers.Add("accept", "application/octet-stream");
                          var resultFile = client.UploadFile(new Uri("http://v2.convertapi.com/docx/to/pdf?Secret=" + Secret), fileToConvert); 
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
      }
    }
