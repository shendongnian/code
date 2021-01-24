            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                var requestUri = "http://localhost:64501/Page1.aspx";
                var stream = httpClient.GetStreamAsync(requestUri).Result;
                string read = "";
                byte[] buffer = new byte[1024];
                while(!stream.EndOfStream)
                {
                    int readed = stream.Read(buffer, 0, 1024);
                    read += Encoding.UTF8.GetString(buffer, 0, readed);
                    //Do whatever you need to do with the string.
                }
            }
