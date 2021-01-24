    static HttpClient client = new HttpClient();
            static string reportServerAddress = "http://localhost:60031/";
            static string serverREStAPI = reportServerAddress + "api/";
    
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Demo started");
    
                    RunAsync().Wait();
    
                    Console.WriteLine("Demo ended");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey();
                }
            }
    
            static async Task RunAsync()
            {
               // readFile();
               // return;
                client.BaseAddress = new Uri(serverREStAPI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
    
    
    
                /*
                 * Steps To get PDF documents from Telerik Self hosted Web Service
                 * Step 1) Get Client Id,
                 * Step 2) Get Instance Id
                 * Step 3) Get Document Id
                 * Step 4) Download Document
                 * 
                 * */
    
                var clientId = await GetClientIdAsync(serverREStAPI + "reports/clients", "clientId");
    
                var instanceId =
                    await GetInstanceAsync(serverREStAPI + $"reports/clients/{clientId}/instances", "instanceId");
                var documentId =
                    await GetDocumentAsync(serverREStAPI + $"reports/clients/{clientId}/instances/{instanceId}/documents",
                        "documentId");
               
                  await DownloadPDF(serverREStAPI + $"reports/clients/{clientId}/instances/{instanceId}/documents/{documentId}", true);
               
    
            }
    
            
    
    
    
            static async Task<string> GetClientIdAsync(string path, string paramName)
            {
    
                HttpResponseMessage response = await client.PostAsJsonAsync(path, "");
                response.EnsureSuccessStatusCode();
    
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic result = serializer.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                return result[paramName];
            }
    
            static async Task<string> GetInstanceAsync(string path, string paramName)
            {
    
                /*
                 * For Default resolver in Service
                 * */
                var paramterValues = new {CompanyId = 1};
                // var data = new { report = "{ \"ReportName\":\"test.trdx\",\"CompanyId\":\"1\"}", parameterValues = "{\"CompanyId\": \"1\"}" };    
                var data = new
                {
                    report = "{\"ReportName\":\"test.trdx\",\"CompanyId\":\"1\"}",
                    parameterValues = paramterValues
                };
    
    
                 
    
    
                HttpResponseMessage response = await client.PostAsJsonAsync(path, data);
                response.EnsureSuccessStatusCode();
    
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic result = serializer.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                return result[paramName];
            }
    
            static async Task<string> GetDocumentAsync(string path, string paramName)
            {
    
    
    
                var data = new {format = "PDF"}; //PDF,XLS,MHTML
                HttpResponseMessage response = await client.PostAsJsonAsync(path, data);
                response.EnsureSuccessStatusCode();
    
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic result = serializer.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                return result[paramName];
            }
    
    
    
            static async Task DownloadPDF(string path, bool asAttachment)
            {
                var queryString = "";
    
                // if (asAttachment)
                //  {
                //  queryString += "?content-disposition=attachment";
                //  }
    
    
    
                var filePathAndName = @"D:\testing\tet.html";
                //   File.Create(filePathAndName);
    
                //  string filePath = System.IO.Path.Combine(folderName, fileName);
    
                //System.IO.File.WriteAllText(filePathAndName, result);
    
    
                using (System.Net.WebClient myWebClient = new System.Net.WebClient())
                {
                    await myWebClient.DownloadFileTaskAsync(new Uri(path + queryString), filePathAndName);
                }
    
    
    
                System.Diagnostics.Process.Start(filePathAndName);
            }
  
             
