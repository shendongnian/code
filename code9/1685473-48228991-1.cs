    String FinalURL = "";
    foreach (string URLt in URLtests)
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(URLt);
                myHttpWebRequest.AllowAutoRedirect = false;
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                int resulting = (int)myHttpWebResponse.StatusCode;
                if (resulting == 200)
                {
                    String Urlnew = URLt;
                    FinalURL = URLt.Replace("https://", "").Replace("http://", "");
                    break;
                }
            }
    if ( FinalURL.Length > 0 )
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.majestic.com/api/json?app_api_key=KEY&cmd=GetIndexItemInfo&items=1&item0=" + FinalURL + "&datasource=fresh");
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    JObject jObject = JObject.Parse(reader.ReadToEnd());
                    JToken Trusty = jObject["DataTables"]["Results"]["Data"][0]["TrustFlow"].Value<int>();
                    JToken City = jObject["DataTables"]["Results"]["Data"][0]["CitationFlow"].Value<int>();
                    JToken RIPy = jObject["DataTables"]["Results"]["Data"][0]["RefIPs"].Value<int>();
    
                    int Trustflow = Int32.Parse(Trusty.ToString());
                    int Citationflow = Int32.Parse(City.ToString());
                    int Reffering = Int32.Parse(RIPy.ToString());
    
                    int[] Metrics = new int[] { Trustflow, Citationflow, Reffering };
    
                    return Metrics;
                }
            }
    }
