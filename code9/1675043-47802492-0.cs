    class Program
    {
        static void Main(string[]args)
        {
            MainAsync(null);
            Console.ReadKey();
        }
        static async System.Threading.Tasks.Task MainAsync(string[] args)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            Dictionary<string, string> values = new Dictionary<string, string>();
            var query = "user=mickey&passwd=mini";
            string[] q = query.Split('&');
            for (int i = 0; i < q.Length; i++)
                values.Add(q[i].Split('=')[0], q[i].Split('=')[1]);
            
            FormUrlEncodedContent content = new FormUrlEncodedContent(values);
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsync(new Uri("https://www.example.com/login.php"), content);
                string answer = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
            }
        }
    }
