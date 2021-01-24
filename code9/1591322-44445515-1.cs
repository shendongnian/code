        string csr = "....";
        char[] characters =
            csr.Replace("-----BEGIN NEW CERTIFICATE REQUEST-----", "")
            .Replace("-----END NEW CERTIFICATE REQUEST-----", "")
            .ToCharArray();
        byte[] csrEncode = Convert.FromBase64CharArray(characters, 0, characters.Length);
        Pkcs10CertificationRequest decodedCsr = new Pkcs10CertificationRequest(csrEncode);
        Console.WriteLine(decodedCsr.GetCertificationRequestInfo().Subject);
