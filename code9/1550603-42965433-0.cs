    var jwtToken = "<JWT TOKEN>";
    var url = "https://login.windows.net/common/federationmetadata/2007-06/federationmetadata.xml";
    var serializer = new MetadataSerializer();
    MetadataBase metadata = serializer.ReadMetadata(XmlReader.Create(url));
    var entityDescriptor = (EntityDescriptor)metadata;
    var securityTokens = new List<X509SecurityToken>();
    var descriptor = entityDescriptor.RoleDescriptors.OfType<SecurityTokenServiceDescriptor>().First();
    var x509DataClauses = descriptor.Keys.Where(key => key.KeyInfo != null &&
                                               (key.Use == KeyType.Signing || key.Use == KeyType.Unspecified))
                                         .Select(key => key.KeyInfo.OfType<X509RawDataKeyIdentifierClause>().First());
    securityTokens.AddRange(x509DataClauses.Select(token => new X509SecurityToken(new X509Certificate2(token.GetX509RawData()))));
    var validationParameters = new TokenValidationParameters
    {
        IssuerSigningTokens = securityTokens,
        CertificateValidator = X509CertificateValidator.ChainTrust,
    };
    SecurityToken validatedToken;
    ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);
