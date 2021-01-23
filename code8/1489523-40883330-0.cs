    if (PdfEncryptor.IsScreenReadersAllowed((int)(r.Permissions)) || !r.IsEncrypted())
    {
        Console.WriteLine("Content Accessibility Enabled");
    }
    if (PdfEncryptor.IsCopyAllowed((int)(r.Permissions)) || !r.IsEncrypted())
    {
        Console.WriteLine("Copy Enabled");
    }
    if (PdfEncryptor.IsAssemblyAllowed((int)(r.Permissions)) || !r.IsEncrypted())
    {
        Console.WriteLine("Document Assembly Enabled");
    }
