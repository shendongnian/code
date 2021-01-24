        class Program {
            static void Main(string[] args) {
                // Fill with a valid xml request
                String inputXML = "";
                String answer = "";
                try {
                    WebReference.rmt_ws _webService = new WebReference.rmt_ws();
                    System.Net.CredentialCache myCredentials = new System.Net.CredentialCache();
                    // Set correct user and password
                    System.Net.NetworkCredential netCred = new System.Net.NetworkCredential("User", "Password");
                    _webService.Credentials = netCred.GetCredential(new Uri(_webService.Url), "Basic");
                    _webService.PreAuthenticate = true;
                    answer = _webService.remittanceXml(inputXML);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(answer);
                Console.ReadLine();
            }
        }
