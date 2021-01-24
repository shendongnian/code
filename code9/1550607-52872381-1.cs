    static void GetTenantInformation(string metadataAddress, out string issuer, out List<X509SecurityToken> signingTokens)
        {
            signingTokens = new List<X509SecurityToken>();
            // The issuer and signingTokens are cached for 24 hours. They are updated if any of the conditions in the if condition is true. 
            if (DateTime.UtcNow.Subtract(_stsMetadataRetrievalTime).TotalHours > 24
            || string.IsNullOrEmpty(_issuer)
            || _signingTokens == null)
            {
                MetadataSerializer serializer = new MetadataSerializer()
                {
                    // turning off certificate validation for demo. Don't use this in production code.
                    CertificateValidationMode = X509CertificateValidationMode.None
                };
                MetadataBase metadata = serializer.ReadMetadata(XmlReader.Create(metadataAddress));
                EntityDescriptor entityDescriptor = (EntityDescriptor)metadata;
                // get the issuer name
                if (!string.IsNullOrWhiteSpace(entityDescriptor.EntityId.Id))
                {
                    _issuer = entityDescriptor.EntityId.Id;
                }
                // get the signing certs
                _signingTokens = ReadSigningCertsFromMetadata(entityDescriptor);
                _stsMetadataRetrievalTime = DateTime.UtcNow;
            }
            issuer = _issuer;
            signingTokens = _signingTokens;
        }
         
