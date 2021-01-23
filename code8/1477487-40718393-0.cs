        public static async Task TalkToWatson()
        {
            var baseurl = "https://gateway.watsonplatform.net/conversation/api";
            var workspace = "04295b5d-f62b-402d-9757-67fd414acefc";
            var username = "670b5cf5-263f-4a69-ab2b-8dca50800d64";
            var password = "ZbKflcHyDNuW";
            var context = null as object;
            var input = Console.ReadLine();
            var message = new { input = new { text = input }, context };
            var resp = await baseurl
                .AppendPathSegments("v1", "workspaces", workspace, "message")
                .WithBasicAuth(username, password)
                .AllowAnyHttpStatus()
                .PostJsonAsync(message);
            var json = await resp.Content.ReadAsStringAsync();
            var answer = new
            {
                intents = null as object,
                entities = null as object,
                input = null as object,
                output = new
                {
                    text = default(string)
                },
                context = null as object
            };
            answer = JsonConvert.DeserializeAnonymousType(json, answer);
            Console.WriteLine($"{resp.StatusCode} {answer?.output?.text}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(json);
            Console.ResetColor();
        }
