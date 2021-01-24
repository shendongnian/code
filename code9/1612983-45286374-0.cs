    static async void DownloadPage()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["text"] = "Bill Gatas";
            queryString["mode"] = "spell";
            var uri = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/?" + queryString;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "e94333d69eb6493d86aaa4b25e42d0d0");
                using (var response = await client.GetAsync(uri))
                {
                    string result = await response .Content.ReadAsStringAsync(); //Put here a breakpoint
                }
            }
        }
