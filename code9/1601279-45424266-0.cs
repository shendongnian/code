    public static void DecodeCsr(string csr)
    {
        csr = Regex.Replace(csr, @"-----[^-]+-----", String.Empty).Trim().Replace(" ", "").Replace(Environment.NewLine, "");
        PemObject pem = new PemObject("CSR", Convert.FromBase64String(csr));
        Pkcs10CertificationRequest request = new Pkcs10CertificationRequest(pem.Content);
        CertificationRequestInfo requestInfo = request.GetCertificationRequestInfo();
        // an Attribute is a collection of Sequence which contains a collection of Asn1Object
        // let's find the sequence that contains a DerObjectIdentifier with Id of "1.2.840.113549.1.9.14"
        DerSequence extensionSequence = requestInfo.Attributes.OfType<DerSequence>()
                                                              .First(o => o.OfType<DerObjectIdentifier>()
                                                                           .Any(oo => oo.Id == "1.2.840.113549.1.9.14"));
        // let's get the set of value for this sequence
        DerSet extensionSet = extensionSequence.OfType<DerSet>().First();
        // estensionSet = [[2.5.29.17, #30158208746573742e636f6d820974657374322e636f6d]]]
        // extensionSet contains nested sequence ... let's use a recursive method 
        DerOctetString str = GetAsn1ObjectRecursive<DerOctetString>(extensionSet.OfType<DerSequence>().First(), "2.5.29.17");
        GeneralNames names = GeneralNames.GetInstance(Asn1Object.FromByteArray(str.GetOctets()));
        Console.WriteLine(names.ToString());
    }
    static T GetAsn1ObjectRecursive<T>(DerSequence sequence, String id) where T : Asn1Object
    {
        if (sequence.OfType<DerObjectIdentifier>().Any(o => o.Id == id))
        {
            return sequence.OfType<T>().First();
        }
        foreach (DerSequence subSequence in sequence.OfType<DerSequence>())
        {
            T value = GetAsn1ObjectRecursive<T>(subSequence, id);
            if (value != default(T))
            {
                return value;
            }
        }
        return default(T);
    }
