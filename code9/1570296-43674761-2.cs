    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;
    namespace Api
    {
        public class ApiCaller
        {
            public async Task<SomeReceivedEntity> CallApiAsync()
            {
                // prepare client
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://uquid.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Api-key", "YourApiKeyString");
                    // your other headers ...
                    // send request
                    var data = new SomeSendedEntity() { ID = 10, Name = "Test" };
                    HttpResponseMessage response = await client.PostAsJsonAsync("api", data);
                    // verify results (throws exception on error response status code)
                    response.EnsureSuccessStatusCode();
                    // read, parse and return response
                    return await response.Content.ReadAsAsync<SomeReceivedEntity>();
                }
            }
        }
        public class SomeSendedEntity
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public class SomeReceivedEntity
        {
            public int ID { get; set; }
            public string Place { get; set; }
        }
    }
