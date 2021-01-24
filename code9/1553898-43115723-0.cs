    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using Newtonsoft.Json;
    
    using DocuSign.eSign.Api;
    using DocuSign.eSign.Model;
    using DocuSign.eSign.Client;
    
    namespace TestProj
    {
        class CoreRecipes
        {
            // Integrator Key (aka API key) is needed to authenticate your API calls.  This is an application-wide key
            private string INTEGRATOR_KEY = "[INTEGRATOR_KEY]";
    
            //////////////////////////////////////////////////////////
            // Main()
            //////////////////////////////////////////////////////////
            static void Main(string[] args)
            {
                CoreRecipes recipes = new CoreRecipes();
                
                //*** TEST 1 - Request Signature (on local document)            
                EnvelopeSummary envSummary = recipes.requestSignatureOnDocumentTest();
    
                Console.Read();
            }
    
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            public EnvelopeSummary requestSignatureOnDocumentTest()
            {
                // Enter your DocuSign credentials below.  Note: You only need a DocuSign account to SEND documents,
                // signing is always free and signers do not need an account.
                string username = "[EMAIL]";
                string password = "[PASSWORD]";
    
                // Enter recipient (signer) name and email address
                string recipientName = "[RECIPIENT_NAME]";
                string recipientEmail = "[RECIPIENT_EMAIL]";
    
                // the document (file) we want signed
                const string SignTest1File = @"[PATH/TO/DOCUMENT/TEST.PDF]";
    
                // instantiate api client with appropriate environment (for production change to www.docusign.net/restapi)
                configureApiClient("https://demo.docusign.net/restapi");
    
                //===========================================================
                // Step 1: Login()
                //===========================================================
    
                // call the Login() API which sets the user's baseUrl and returns their accountId
                string accountId = loginApi(username, password);
    
                //===========================================================
                // Step 2: Signature Request (AKA create & send Envelope)
                //===========================================================
    
                // Read a file from disk to use as a document.
                byte[] fileBytes = File.ReadAllBytes(SignTest1File);
    
                EnvelopeDefinition envDef = new EnvelopeDefinition();
                envDef.EmailSubject = "[DocuSign C# SDK] - Please sign this doc";
    
                // Add a document to the envelope
                Document doc = new Document();
                doc.DocumentBase64 = System.Convert.ToBase64String(fileBytes);
                doc.Name = "TestFile.pdf";
                doc.DocumentId = "1";
    
                envDef.Documents = new List<Document>();
                envDef.Documents.Add(doc);
    
                // Add a recipient to sign the documeent
                Signer signer = new Signer();
                signer.Email = recipientEmail;
                signer.Name = recipientName;
                signer.RecipientId = "1";
    
                // Create a |SignHere| tab somewhere on the document for the recipient to sign
                signer.Tabs = new Tabs();
                signer.Tabs.SignHereTabs = new List<SignHere>();
                SignHere signHere = new SignHere();
                signHere.DocumentId = "1";
                signHere.PageNumber = "1";
                signHere.RecipientId = "1";
                signHere.XPosition = "100";
                signHere.YPosition = "100";
                signer.Tabs.SignHereTabs.Add(signHere);
    
                envDef.Recipients = new Recipients();
                envDef.Recipients.Signers = new List<Signer>();
                envDef.Recipients.Signers.Add(signer);
    
                // set envelope status to "sent" to immediately send the signature request
                envDef.Status = "sent";
    
                // |EnvelopesApi| contains methods related to creating and sending Envelopes (aka signature requests)
                EnvelopesApi envelopesApi = new EnvelopesApi();
                EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(accountId, envDef);
    
                // print the JSON response
                Console.WriteLine("EnvelopeSummary:\n{0}", JsonConvert.SerializeObject(envelopeSummary));
    
                // *** I added a code here ***
                Tabs tabs = envelopesApi.ListTabs(accountId, envelopeSummary.EnvelopeId, "1");
                // *** I added a code here ***
    
                return envelopeSummary;
    
            } // end requestSignatureTest()
    
            //**********************************************************************************************************************
            //**********************************************************************************************************************
            //*  HELPER FUNCTIONS
            //**********************************************************************************************************************
            //**********************************************************************************************************************
            public void configureApiClient(string basePath)
            {
                // instantiate a new api client
                ApiClient apiClient = new ApiClient(basePath);
    
                // set client in global config so we don't need to pass it to each API object.
                Configuration.Default.ApiClient = apiClient;
            }
    
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            public string loginApi(string usr, string pwd)
            {
                // we set the api client in global config when we configured the client 
                ApiClient apiClient = Configuration.Default.ApiClient;
                string authHeader = "{\"Username\":\"" + usr + "\", \"Password\":\"" + pwd + "\", \"IntegratorKey\":\"" + INTEGRATOR_KEY + "\"}";
                Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", authHeader);
    
                // we will retrieve this from the login() results
                string accountId = null;
    
                // the authentication api uses the apiClient (and X-DocuSign-Authentication header) that are set in Configuration object
                AuthenticationApi authApi = new AuthenticationApi();
                LoginInformation loginInfo = authApi.Login();
    
                // find the default account for this user
                foreach (LoginAccount loginAcct in loginInfo.LoginAccounts)
                {
                    if (loginAcct.IsDefault == "true")
                    {
                        accountId = loginAcct.AccountId;
                        break;
                    }
                }
                if (accountId == null)
                { // if no default found set to first account
                    accountId = loginInfo.LoginAccounts[0].AccountId;
                }
                return accountId;
            }
    
        } // end class
    } // end namespace
