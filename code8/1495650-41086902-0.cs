    Uri url = new Uri("http://lu32kap.typo3.lrz.de/mensaapp/exportDB.php?mensa_id=all");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            IHttpContent content = response.Content;
            if(content != null)
            {
                IBuffer buffer = await content.ReadAsBufferAsync();
                using (DataReader dataReader = DataReader.FromBuffer(buffer))
                {
                    string result = dataReader.ReadString(buffer.Length);
                    if (result != null)
                    {
                        tblock.Text = result;
                    }
                }
            }
