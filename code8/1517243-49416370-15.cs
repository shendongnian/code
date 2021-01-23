    var cert = new X509Certificate2(keypairBytes, password,
                                    X509KeyStorageFlags.Exportable 
                                    | X509KeyStorageFlags.MachineKeySet);
    var partialAsnBlockWithPublicKey = cert.GetPublicKey();
    // export bytes to PEM format
    var base64Encoded = Convert.ToBase64String(partialAsnBlockWithPublicKey, Base64FormattingOptions.InsertLineBreaks);
    var pemHeader = "-----BEGIN PUBLIC KEY-----";
    var pemFooter = "-----END PUBLIC KEY-----";
    var pemFull = string.Format("{0}\r\n{1}\r\n{2}", pemHeader, base64Encoded, pemFooter);
