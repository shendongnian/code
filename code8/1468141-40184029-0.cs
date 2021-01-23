    private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                // default validation bool to false
                var isValid = false;
    
                // If the certificate is a valid, signed certificate, return true to short circuit any add'l processing.
                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                }
                else
                {
                    // cast cert as v2 in order to expose thumbprint prop
                    var requestCertificate = (X509Certificate2)certificate;
    
                    // init string builder for creating a long log entry
                    var logEntry = new StringBuilder();
    
                    // capture initial info for the log entry
                    logEntry.AppendFormat("Certificate Validation Error - SSL Policy Error: {0} - Cert Issuer: {1} - SubjectName: {2}",
                       sslPolicyErrors.ToString(),
                       requestCertificate.Issuer,
                       requestCertificate.SubjectName.Name);
    
                    //init special builder for thumprint mismatches
                    var thumbprintMismatches = new StringBuilder();
    
                    // load valid certificate thumbs for comparison later
                    var validThumbprints = new string[] { "thumbprint A", "thumbprint N" };
    
                    // else if a cert name mismatch then assume api pass thru issue and verify thumb print
                    if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch) 
                    {
                        // compare thumbprints
                        var hasMatch = validThumbprints.Contains(requestCertificate.Thumbprint, StringComparer.OrdinalIgnoreCase);
    
                        // if match found then we're valid so clear builder and set global valid bool to true
                        if (hasMatch)
                        {
                            thumbprintMismatches.Clear();
                            isValid = true;
                        }
                        // else thumbprint did not match so append to the builder
                        else
                        {
                            thumbprintMismatches.AppendFormat("|Thumbprint mismatch - Issuer: {0} - SubjectName: {1} - Thumbprint: {2}",
                                 requestCertificate.Issuer,
                                 requestCertificate.SubjectName.Name,
                                 requestCertificate.Thumbprint);
                        }
                    }
                    // else if chain issue, then iterate over the chain and attempt find a matching thumbprint
                    else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) //Root CA problem
                    {
                        // check chain status and log
                        if (chain != null && chain.ChainStatus != null)
                        {
                            // check errors in chain and add to log entry
                            foreach (var chainStatus in chain.ChainStatus)
                            {
                                logEntry.AppendFormat("|Chain Status: {0} - {1}", chainStatus.Status.ToString(), chainStatus.StatusInformation.Trim());
                            }
    
                            // check for thumbprint mismatches
                            foreach (var chainElement in chain.ChainElements)
                            {
                                // compare thumbprints
                                var hasMatch = validThumbprints.Contains(chainElement.Certificate.Thumbprint, StringComparer.OrdinalIgnoreCase);
    
                                // if match found then we're valid so break, clear builder and set global valid bool to true
                                if (hasMatch)
                                {
                                    thumbprintMismatches.Clear();
                                    isValid = true;
                                    break;
                                }
                                // else thumbprint did not match so append to the builder
                                else
                                {
                                    thumbprintMismatches.AppendFormat("|Thumbprint mismatch - Issuer: {0} - SubjectName: {1} - Thumbprint: {2}",
                                         chainElement.Certificate.Issuer,
                                         chainElement.Certificate.SubjectName.Name,
                                         chainElement.Certificate.Thumbprint);
                                }
                            }
                        }
                    }
    
                    // if still invalid and thumbprint builder has items, then continue 
                    if (!isValid && thumbprintMismatches != null && thumbprintMismatches.Length > 0)
                    {
                        // append thumbprint entries to the logentry as well
                        logEntry.Append(thumbprintMismatches.ToString());
                    }
    
                    // log as WARN here and not ERROR - if method ends up returning false then it will bubble up and get logged as an ERROR
                    LogHelper.Instance.Warning((int)ErrorCode.CertificateValidation, logEntry.ToString().Trim());
                }
    
                // determine env
                var isDev = EnvironmentHelper.IsDevelopment();
                var isTest = EnvironmentHelper.IsTest();
    
                // if env is dev or test then ignore cert errors and return true (reference any log entries created from logic above for troubleshooting)
                if (isDev || isTest)
                    isValid = true;
    
                return isValid;
            }
