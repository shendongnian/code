        namespace TestWeb.WebReference 
        {
        partial class rmt_ws : System.Web.Services.Protocols.SoapHttpClientProtocol {
            protected override System.Net.WebRequest GetWebRequest(Uri uri) 
            {
                System.Net.HttpWebRequest request;
    
                request = (System.Net.HttpWebRequest)base.GetWebRequest(uri);
    
                if (PreAuthenticate) {
                    System.Net.NetworkCredential networkCredentials = Credentials.GetCredential(uri, "Basic");
                    if (networkCredentials != null) {
                        System.Diagnostics.Debug.WriteLine("User: " + networkCredentials.UserName);
                        System.Diagnostics.Debug.WriteLine("PW: " + networkCredentials.Password);
                        byte[] credentialBuffer = new UTF8Encoding().GetBytes(networkCredentials.UserName + ":" + networkCredentials.Password);
                        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                    }
                    else {
                        throw new ApplicationException("No network credentials");
                    }
                }
                return request;
            }
        }
    
