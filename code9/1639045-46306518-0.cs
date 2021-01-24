    class Program
    {
        static void Main()
        {
            Task.Factory.StartNew(async () =>
            {
                var repoOwner = "crs2007";
                var repoName = "ActiveReport";
                var path = "ActiveReport";
                var httpClientResults = await PullViaHttpClient(repoOwner, repoName, path);
                PrintResults("From HttpClient", httpClientResults);
                var octokitResults = await PullViaOctokit(repoOwner, repoName, path);
                PrintResults("From Octokit", octokitResults);
            }).Wait();
            Console.ReadKey();
        }
        static async Task<IEnumerable<string>> PullViaHttpClient(string repoOwner, string repoName, string path)
        {
            using (var client = GetGithubHttpClient())
            {
                var resp = await client.GetAsync($"repos/{repoOwner}/{repoName}/contents/{path}");
                var bodyString = await resp.Content.ReadAsStringAsync();
                // uses Newtonsoft.Json
                var bodyJson = JToken.Parse(bodyString);
                return bodyJson.SelectTokens("$.[*].name").Select(token => token.Value<string>());
            }
        }
        static async Task<IEnumerable<string>> PullViaOctokit(string repoOwner, string repoName, string path)
        {
            var client = new GitHubClient(new ProductHeaderValue("Github-API-Test"));
            // client.Credentials = ... // Set credentials here...
            var contents = await client.Repository.Content.GetAllContents(repoOwner, repoName, path);
            return contents.Select(content => content.Name);
        }
        private static HttpClient GetGithubHttpClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com"),
                DefaultRequestHeaders =
                {
                    // NOTE: You'll have to set up Authentication tokens in real use scenario
                    // NOTE: as without it you're subject to harsh rate-limits
                    {"User-Agent", "Github-API-Test"}
                }
            };
        }
        static void PrintResults(string source, IEnumerable<string> files)
        {
            Console.WriteLine(source);
            foreach (var file in files)
            {
                Console.WriteLine($" -{file}");
            }
        }
    }
