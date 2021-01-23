            private async Task ConnectToServerHttpAsync(Uri connectUri)
            {
                HttpRequestMessage req = null;
                try
                {
                    using (HttpBaseProtocolFilter bpf = new HttpBaseProtocolFilter())
                    {
                        bpf.AllowUI = false;
                        bpf.ServerCustomValidationRequested += ServerCustomValidationRequested;
                        bpf.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
                        using (HttpClient httpClient = new HttpClient(bpf))
                        {
                            req = new HttpRequestMessage(HttpMethod.Get, connectUri);
                            using (HttpResponseMessage res = await httpClient.SendRequestAsync(req))
                            {
                                Status = ((int)(res.StatusCode)) + " " + res.ReasonPhrase;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    SocketErrorStatus eSocketErrorStatus = SocketError.GetStatus(ex.HResult);
                    Status = eSocketErrorStatus.ToString();
                    Status = req?.TransportInformation?.ServerCertificate?.ToString() ?? "No server certificate.";
                }
                req?.Dispose();
            }
    
            private void ServerCustomValidationRequested(HttpBaseProtocolFilter sender, HttpServerCustomValidationRequestedEventArgs customValidationArgs)
            {
                Status = "-----ServerCustomValidationRequested-----";
                Status = "Certificate details:";
                Status = "Friendly name: " + customValidationArgs.ServerCertificate.FriendlyName;
                Status = "Issuer: " + customValidationArgs.ServerCertificate.Issuer;
                Status = "SignatureAlgorithmName: " + customValidationArgs.ServerCertificate.SignatureAlgorithmName;
                Status = "SignatureHashAlgorithmName: " + customValidationArgs.ServerCertificate.SignatureHashAlgorithmName;
                Status = "Subject: " + customValidationArgs.ServerCertificate.Subject;
                Status = "ValidFrom: " + customValidationArgs.ServerCertificate.ValidFrom.ToString();
                Status = "ValidTo: " + customValidationArgs.ServerCertificate.ValidTo.ToString();
    
                ServerCert = customValidationArgs.ServerCertificate;
    // Validate the server certificate as required.
    //            customValidationArgs.Reject();
            }
