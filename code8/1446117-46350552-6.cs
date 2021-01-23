    static String GetPublicKeyPinningHash(X509Certificate2 x509Cert)
    {
            //Public Domain: No attribution required
            //Get the SubjectPublicKeyInfo member of the certificate
            Byte[] subjectPublicKeyInfo = GetSubjectPublicKeyInfoRaw(x509Cert);
    
            //Take the SHA2-256 hash of the DER ASN.1 encoded value
            Byte[] digest;
            using (var sha2 = new SHA256Managed())
            {
                digest = sha2.ComputeHash(subjectPublicKeyInfo);
            }
    
            //Convert hash to base64
            String hash = Convert.ToBase64String(digest);
    
            return hash;
    }
