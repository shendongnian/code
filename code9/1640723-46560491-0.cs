    string json;
            WebRequest req = HttpWebRequest.Create(url);
            req.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader responseReader = new StreamReader(responseStream))
                    {
                        json = responseReader.ReadToEnd();
                    }
                }
            }
