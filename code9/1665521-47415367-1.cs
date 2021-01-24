    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    namespace WebApiTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                RunAsync().Wait();
            }
            static async Task RunAsync()
            {
                // Before using, "Install-Package Microsoft.AspNet.WebApi.Client"
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:56409/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Person person = null;
                HttpResponseMessage response = await client.GetAsync("api/People/1");
                if (response.IsSuccessStatusCode)
                {
                    person = await response.Content.ReadAsAsync<Person>();
                }
                Console.WriteLine("Id: {0}, Person: {1}", person.Id, person.Name);
                Console.ReadKey();
            }
        }
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
