    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Configuration;
    using Newtonsoft.Json;
    
    namespace JSONandHTTPClient
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                callJSONandHTTPClientApp();
    
            }
    
            static void callJSONandHTTPClientApp()
            {
                using (var client = new HttpClient())
                {
                    var parameters = new Dictionary<string, string>();
                    parameters["address_line1"] = "1600 Pennsylvania Ave NW";
                    parameters["address_city"] = "Washington";
                    parameters["address_state"] = "DC";
                    parameters["address_zip"] = "20050";
    
                    client.BaseAddress = new Uri("https://api.lob.com");
    
                    client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "test_xxxxxxxxxxxxxxxxxxxxxxxxxxxxx", ""))));
                                    
                    var justJSON = JsonConvert.SerializeObject(parameters).ToString();
    
                    var value = new StringContent(justJSON, Encoding.UTF8, "application/json");
    
                    var response = client.PostAsync("v1/verify", value).Result;
                    
                    if (response.IsSuccessStatusCode)
                    {
                        dynamic content = JsonConvert.DeserializeObject(
                            response.Content.ReadAsStringAsync()
                            .Result);
                        
                        Console.WriteLine(content.ToString());
                    }
    
                    Console.ReadLine();
                }
            
            }
        }
    }
