    using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:55272/myDll.dll";
                using (var response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    using (var inputStream = await response.Content.ReadAsStreamAsync())
                    {
                        var mydll = AssemblyLoadContext.Default.LoadFromStream(inputStream);
                    }
                }
            }
