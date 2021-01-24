                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(sharepointUrl.ToString() + "/_api/web/lists");
                string password = "XXXXX";
                string userName = "XXXX";
                SecureString secureString = new SecureString();
                foreach (char c in password.ToCharArray())
                {
                    secureString.AppendChar(c);
                }
                endpointRequest.Credentials = new SharePointOnlineCredentials(userName, secureString);
                //.........
