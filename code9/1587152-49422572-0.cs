    Other Name:
        Principal Name=john.doe@contoso.com
    RFC822 Name=john.doe@contoso.com
    certificateGenerator.AddExtension(X509Extensions.SubjectAlternativeName.Id, false, new DerSequence(
                new GeneralName(GeneralName.OtherName,
                    new DerSequence(new DerObjectIdentifier("1.3.6.1.4.1.311.20.2.3"),
                        new DerTaggedObject(0, new DerUtf8String("john.doe@contoso.com")))),
                new GeneralName(GeneralName.Rfc822Name, "john.doe@costoso.com")));
