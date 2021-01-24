                        var authorityKeyIdentifierExtension =
                    new AuthorityKeyIdentifier(
                        SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(issuerKeyPair.Public),
                        new GeneralNames(new GeneralName(issuerDN)),
                        issuerSerialNumber);
                    certificateGenerator.AddExtension(
                        X509Extensions.AuthorityKeyIdentifier.Id, false, authorityKeyIdentifierExtension);
