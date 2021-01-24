    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    
    namespace GetTeamProjectREST
    {
        class Program
        {
            public static void Main()
            {
                Task t = GetTeamProjectREST();
                Task.WaitAll(new Task[] { t});
            }
            private static async Task GetTeamProjectREST()
            {
                try
                {
                    var username = "domain\\username";
                    var password = "password";
    
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(
                            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(
                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                    string.Format("{0}:{1}", username, password))));
    
                        using (HttpResponseMessage response = client.GetAsync(
                                    "http://tfsserver:8080/tfs/teamprojectCollection/_apis/projects?api-version=2.2").Result)
                        {
                            response.EnsureSuccessStatusCode();
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(responseBody);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
