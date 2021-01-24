            //for service certificate
            client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.LocalMachine, StoreName.TrustedPeople,
                X509FindType.FindByThumbprint, "xxxxxxxxxxxxxxxxy");
            client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                X509CertificateValidationMode.PeerOrChainTrust;
            //add faultformattingbehavior so we can intercept the fault reply message
            client.Endpoint.EndpointBehaviors.Add(new MyFaultFormatterBehavior());
            client.Open();
            var header = new AuthenticationHeader()
            {
                application_id = applId,
                password = pwd
            };
            
            var getActiveAccountsFunc = new getActiveAccounts() { applRef = "test", resetRows = true };
            try
            {
                //MyClientMessageInspector.BeforeSendRequest is entered when this called is made
                var response = client.getActiveAccounts(header, getActiveAccountsFunc);
                Console.WriteLine(response.moreData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
