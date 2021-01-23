    public class FacebookService : IFacebookService
        private string accesstoken;
        private string API_BaseUrl;
    
        public FacebookService(ITokenProvider tokens, IUrlProvider urls) {
            accessToken = tokens.GetAccessToken();
            API_BaseUrl = url.GetBaseUrl();
        }
    
        public  string Getfriends() {
            string retVal = "";
            string url = API_BaseUrl + "/me/invitable_friends?&access_token=" + accesstoken;
            System.Net.HttpWebRequest request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            System.Net.HttpWebResponse response = null;
            try {
                using (response = request.GetResponse() as System.Net.HttpWebResponse) {
                    System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                    retVal = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
    
            }
            return retVal;
        }
    }
    
