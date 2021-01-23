    private string GetToken()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://www.arcgis.com/sharing/rest/oauth2/token/");
    
            var postData = "client_id=yourclientid"; //required
            postData += "&client_secret=yourclientsecret"; //required
            postData += "&grant_type=client_credentials"; //required
            postData += "&expiration=120"; //optional, default
            var data = Encoding.ASCII.GetBytes(postData);
    
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
    
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
    
            var response = (HttpWebResponse)request.GetResponse();
    
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
    
            ESRITokenResponse eToken = Newtonsoft.Json.JsonConvert.DeserializeObject<ESRITokenResponse>(responseString);
    
            return eToken.access_token;
        }
    public class ESRITokenResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }
