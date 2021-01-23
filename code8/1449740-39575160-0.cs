    var certs = new X509Certificate2Collection();
    foreach (var certFile in fDialog.FileNames)
    {
        certs.Add(new X509Certificate2(certFile));
    }
    byte[] oneBigPfx = certs.Export(X509ContentType.Pfx);
    File.WriteAllBytes(filename, oneBigPfx);
