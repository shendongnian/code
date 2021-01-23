        static Byte[] GetSubjectPublicKeyInfoRaw(X509Certificate2 x509Cert)
        {
            //Public Domain: No attribution required
            Byte[] rawCert = x509Cert.GetRawCertData();
    
            /*
             Certificate is, by definition:
              
                Certificate  ::=  SEQUENCE  {
                    tbsCertificate       TBSCertificate,
                    signatureAlgorithm   AlgorithmIdentifier,
                    signatureValue       BIT STRING  
                }
    
               TBSCertificate  ::=  SEQUENCE  {
                    version         [0]  EXPLICIT Version DEFAULT v1,
                    serialNumber         CertificateSerialNumber,
                    signature            AlgorithmIdentifier,
                    issuer               Name,
                    validity             Validity,
                    subject              Name,
                    subjectPublicKeyInfo SubjectPublicKeyInfo,
                    issuerUniqueID  [1]  IMPLICIT UniqueIdentifier OPTIONAL, -- If present, version MUST be v2 or v3
                    subjectUniqueID [2]  IMPLICIT UniqueIdentifier OPTIONAL, -- If present, version MUST be v2 or v3
                    extensions      [3]  EXPLICIT Extensions       OPTIONAL  -- If present, version MUST be v3
                }
    
            So we walk to ASN.1 DER tree in order to drill down to the SubjectPublicKeyInfo item
            */
            Byte[] list = AsnNext(ref rawCert, true); //unwrap certificate sequence
            Byte[] tbsCertificate = AsnNext(ref list, false); //get next item; which is tbsCertificate
            list = AsnNext(ref tbsCertificate, true); //unwap tbsCertificate sequence
    
            Byte[] version = AsnNext(ref list, false); //tbsCertificate.Version
            Byte[] serialNumber = AsnNext(ref list, false); //tbsCertificate.SerialNumber
            Byte[] signature = AsnNext(ref list, false); //tbsCertificate.Signature
            Byte[] issuer = AsnNext(ref list, false); //tbsCertificate.Issuer
            Byte[] validity = AsnNext(ref list, false); //tbsCertificate.Validity
            Byte[] subject = AsnNext(ref list, false); //tbsCertificate.Subject        
            Byte[] subjectPublicKeyInfo = AsnNext(ref list, false); //tbsCertificate.SubjectPublicKeyInfo        
    
            return subjectPublicKeyInfo;
        }
