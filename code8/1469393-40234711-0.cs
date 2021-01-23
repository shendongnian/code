        byte [] certbyte = File.ReadAllBytes("D:\\certsunzip\\DODIDCA_44.crl");
        Console.WriteLine("First byte: {0}", certbyte[0]);
        string pem = "-----BEGIN X509 CRL-----\r\n" + Convert.ToBase64String(certbyte, Base64FormattingOptions.InsertLineBreaks) + "-----END X509 CRL-----";
        using (StreamWriter outputFile = new StreamWriter(@"D:\certsunzip\test.crl"))
        {
            foreach (char chr in pem)
            outputFile.WriteLine(chr);
        }
    }
