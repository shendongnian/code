                HttpWebRequest init = (HttpWebRequest)WebRequest.Create("https://accounts.spotify.com/en/login?continue=https:%2F%2Fwww.spotify.com%2Fus%2Faccount%2Foverview%2F");
                init.Method = "GET";
                init.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
                init.Timeout = 8000;
                HttpWebResponse resp1 = (HttpWebResponse)init.GetResponse();
                HttpStatusCode sc = resp1.StatusCode;
                String sd = resp1.StatusDescription;
                string HtmlResult = "";
                string responseBody = "";
                using (System.IO.Stream rspStm = resp1.GetResponseStream())
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(rspStm))
                    {
                        HtmlResult = HtmlResult +
                            "Response Description: " + resp1.StatusDescription;
                        HtmlResult = HtmlResult +
                            "Response Status Code: " + resp1.StatusCode;
                        HtmlResult = HtmlResult + "\r\n\r\n";
                        responseBody = reader.ReadToEnd();
                    }
                }
