    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net; 
    using System.Runtime.Serialization; 
    using System.Runtime.Serialization.Json; 
    
    namespace VerifyRESTTest
    {
        class Program
        {
            // Class used for serializing the OAuth JSON response
            [DataContract]
            public class OAuthUsernamePasswordResponse
            {
                [DataMember]
                public string access_token { get; set; }
                [DataMember]
                public string id { get; set; }
                [DataMember]
                public string instance_url { get; set; }
                [DataMember]
                public string issued_at { get; set; }
                [DataMember]
                public string signature { get; set; }
            }
    
            private static string accessToken = "";
            private static string instanceUrl = "";
            private static void login()
            {
                string acctName = "########@gmail.com";
                string acctPw = "##############";
                string consumerKey = "###############################################";
                string consumerSecret = "#################";
                // Just for testing the developer environment, we use the simple username-password OAuth flow.
                // In production environments, make sure to use a stronger OAuth flow, such as User-Agent
                string strContent = "grant_type=password" + 
                    "&client_id=" + consumerKey + 
                    "&client_secret=" + consumerSecret + 
                    "&username=" + acctName + 
                    "&password=" + acctPw;
                string urlStr = "https://############-dev-ed.my.salesforce.com/services/oauth2/token?" + strContent;
                HttpWebRequest request = WebRequest.Create(urlStr) as HttpWebRequest;
                request.Method = "POST";
    
                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                            throw new Exception(String.Format(
                                "Server error (HTTP {0}: {1}).",
                                response.StatusCode,
                                response.StatusDescription));
                        // Parse the JSON response and extract the access token and instance URL
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(OAuthUsernamePasswordResponse));
                        OAuthUsernamePasswordResponse objResponse = jsonSerializer.ReadObject(response.GetResponseStream()) as OAuthUsernamePasswordResponse;
                        accessToken = objResponse.access_token;
                        instanceUrl = objResponse.instance_url;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            static void Main(string[] args)
            {
                login(); 
                if (accessToken != "") 
                {
                    // display some current login settings
                    Console.Write("Instance URL: " + instanceUrl + "\n");
                    Console.Write("Access Token: " + accessToken + "\n");
                    Console.Write("Press any key to continue:\n");
                    Console.ReadKey();
                }
            }
        }
    }
