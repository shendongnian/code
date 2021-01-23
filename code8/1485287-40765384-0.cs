     using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/xml");
                client.Headers.Add("Accept", "application/xml");
                client.Headers.Add("Authorization", "Token " + Token);
                using (Stream fileStream = File.OpenRead(@"C:\xxx\yyy\zzz.xml"))
                using (Stream requestStream = client.OpenWrite(new Uri("https://xxx/yyy/zzz"), "POST"))
                {
                    fileStream.CopyTo(requestStream);
                }
            }
