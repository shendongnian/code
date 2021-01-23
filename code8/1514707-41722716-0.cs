        private async void button1_Click(object sender, EventArgs e)
        {
            string signatureLocal = "";
            string[] dataFields;
            string userEmail;
            int position = 0;
            string stat = "";
            string certPath=appPath + "saKey.p12";
            var cert = new X509Certificate2(certPath, "notasecret", X509KeyStorageFlags.Exportable);
            string[] scopes = new string[] {GmailService.Scope.GmailSettingsBasic, GmailService.Scope.MailGoogleCom};
            try
            {
                SendAs sendAsObj = new SendAs();
                foreach (string line in csvData_Arr)
                {
                    if (position == 0)
                    {
                        // skip this step, this is the header
                        position++;
                    }
                    else
                    {
                        dataFields = line.Split(',');
                        userEmail = dataFields[0];
                        updateOutput("Trying to authorize with Google", "I");
                        ServiceAccountCredential cred = new ServiceAccountCredential(
                            new ServiceAccountCredential.Initializer("xxx@cool-monolith-153015.iam.gserviceaccount.com")
                            {
                                User = userEmail,
                                Scopes = scopes
                            }.FromCertificate(cert));
                        updateOutput("Authorized successfully", "I");
                        serviceSA = new GmailService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = cred,
                            ApplicationName = "Gmail API - Signature Manager",
                        });
                        signatureLocal = mapSignatureFields(signatureText, dataFields);
                        updateOutput("Updating signature for: " + userEmail, "I");
                        sendAsObj.SendAsEmail = userEmail;
                        sendAsObj.Signature = signatureLocal;
                        serviceSA.Users.Settings.SendAs.Patch(sendAsObj, userEmail, userEmail).Execute();
                        UsersResource.SettingsResource.SendAsResource.GetRequest sendAsRes = serviceSA.Users.Settings.SendAs.Get(userEmail, userEmail);
                        if (chkGetbackSig.Checked == true)
                        {
                            updateOutput(sendAsRes.Execute().Signature.ToString(), "D");
                        }
                        updateOutput(stat, "D");
                        if (chkGetbackSig.Checked == true)
                        {
                            updateOutput("Final signature: " + signatureLocal, "I");
                        }
                        position++;
                    }
                }
                    
            }
            catch (Google.GoogleApiException ex)
            {
                updateOutput(ex.Message, "E");
            }
        }
