    if (keyPurposeId != null)
    {
        certificateGenerator.AddExtension(
            X509Extensions.ExtendedKeyUsage.Id,
            false,
            new ExtendedKeyUsage(keyPurposeId));
        // new extension not present in your question's code
        certificateGenerator.AddExtension(
            "1.3.6.1.5.5.7.3.2",
            false,
            new ExtendedKeyUsage(KeyPurposeID.IdKPClientAuth));
    }
