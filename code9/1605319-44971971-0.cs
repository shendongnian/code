            var word = Console.ReadLine();
            string webURL = @"https://nl.wiktionary.org/wiki/" + word.ToLower();
            using (WebClient client = new WebClient() {  })
            {
                try
                {
                    string htmlCode = client.DownloadString(webURL);
                }
                catch (WebException exception)
                {
                    string responseText=string.Empty;
                    var responseStream = exception.Response?.GetResponseStream();
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseText = reader.ReadToEnd();
                        }
                    }
                    Console.WriteLine(responseText);
                }
            }
            Console.ReadLine();
