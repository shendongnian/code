    using (var cert = new X509Certificate2(someBytes, pass))
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("-----BEGIN CERTIFICATE-----");
        builder.AppendLine(
            Convert.ToBase64String(cert.RawData, Base64FormattingOptions.InsertLineBreaks));
        builder.AppendLine("-----END CERTIFICATE-----");
        return builder.ToString();
    }
