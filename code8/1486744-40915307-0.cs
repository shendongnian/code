    var cert = Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(x509certificate);
    
    using (var stringWriter = new StringWriter())
    {
        var pemWriter = new Org.BouncyCastle.OpenSsl.PemWriter(stringWriter);
        pemWriter.WriteObject(cert.GetPublicKey());
        var pem = stringWriter.ToString();
    }
