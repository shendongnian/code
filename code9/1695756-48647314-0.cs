    using (RSA rsa1 = new RSACng(2048))
    using (RSACng rsa2 = new RSACng())
    {
        rsa2.ImportParameters(rsa1.ExportParameters(true));
        rsa2.Key.SetProperty(
            new CngProperty(
                "Export Policy",
                BitConverter.GetBytes((int)CngExportPolicies.AllowPlaintextExport),
                CngPropertyOptions.Persist));
        RSAParameters params2 = rsa2.ExportParameters(true);
        Console.WriteLine(params2.D.Length);
    }
