            const string secret = "<YourSecret>";
            const string url = "http://www.google.com";
            const int conversionDelay = 1;
            const string fileToSave = @"C:\Projects\_temp\test1.pdf";
            using (var client = new WebClient())
            {
                client.Headers.Add("accept", "application/octet-stream");
                var response = new byte[] { };
                try
                {
                    response = client.UploadValues("https://v2.convertapi.com/web/to/pdf?secret=" + secret, "POST", new NameValueCollection
                    {
                        { "Url", url },
                        { "ConversionDelay", conversionDelay.ToString() }
                    });
                }
                catch (WebException e)
                {
                    Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                    Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                    Console.WriteLine("Body : {0}", new StreamReader(e.Response.GetResponseStream()).ReadToEnd());
                }
                if (response != null)
                    File.WriteAllBytes(fileToSave, response);
            }
