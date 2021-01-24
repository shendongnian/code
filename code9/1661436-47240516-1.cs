    using System;
    using System.Collections.Generic;
    using System.Security;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography;
    using System.Net.Security;
    namespace test
    {
        public sealed class Certificates
        {
            private static Certificates instance = null;
            private static readonly object padlock = new object();
            Certificates()
            {
            }
            public static Certificates Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Certificates();
                        }
                        return instance;
                    }
                }
            }
            public void GetCertificatesAutomatically()
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors)
                        => { return true; });
            }
            private static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                //Return true if the server certificate is ok
                if (sslPolicyErrors == SslPolicyErrors.None)
                    return true;
                bool acceptCertificate = true;
                string msg = "The server could not be validated for the following reason(s):\r\n";
                //The server did not present a certificate
                if ((sslPolicyErrors &
                    SslPolicyErrors.RemoteCertificateNotAvailable) == SslPolicyErrors.RemoteCertificateNotAvailable)
                {
                    msg = msg + "\r\n    -The server did not present a certificate.\r\n";
                    acceptCertificate = false;
                }
                else
                {
                    //The certificate does not match the server name
                    if ((sslPolicyErrors &
                        SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch)
                    {
                        msg = msg + "\r\n    -The certificate name does not match the authenticated name.\r\n";
                        acceptCertificate = false;
                    }
                    //There is some other problem with the certificate
                    if ((sslPolicyErrors &
                        SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors)
                    {
                        foreach (X509ChainStatus item in chain.ChainStatus)
                        {
                            if (item.Status != X509ChainStatusFlags.RevocationStatusUnknown &&
                                item.Status != X509ChainStatusFlags.OfflineRevocation)
                                break;
                            if (item.Status != X509ChainStatusFlags.NoError)
                            {
                                msg = msg + "\r\n    -" + item.StatusInformation;
                                acceptCertificate = false;
                            }
                        }
                    }
                }
                //If Validation failed, present message box
                if (acceptCertificate == false)
                {
                    msg = msg + "\r\nDo you wish to override the security check?";
                    //          if (MessageBox.Show(msg, "Security Alert: Server could not be validated",
                    //                       MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    acceptCertificate = true;
                }
                return acceptCertificate;
            }
        }
    }
