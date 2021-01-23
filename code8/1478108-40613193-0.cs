    List<SecurityToken> _tokens;
    public Saml2SSOSecurityTokenResolver(List<SecurityToken> tokens)
    {
        _tokens = tokens;
    }
    protected override bool TryResolveSecurityKeyCore(System.IdentityModel.Tokens.SecurityKeyIdentifierClause keyIdentifierClause, out System.IdentityModel.Tokens.SecurityKey key)
    {
        var token = _tokens[0] as X509SecurityToken;
        var myCert = token.Certificate;
        key = null;
        var ekec = keyIdentifierClause as EncryptedKeyIdentifierClause;
        if (ekec != null)
        {
            if (ekec.EncryptionMethod == "http://www.w3.org/2001/04/xmlenc#rsa-1_5")
            {
                var encKey = ekec.GetEncryptedKey();
                var rsa = myCert.PrivateKey as RSACryptoServiceProvider;
                var decKey = rsa.Decrypt(encKey, false);
                key = new InMemorySymmetricSecurityKey(decKey);
                return true;
            }
            var data = ekec.GetEncryptedKey();
            var id = ekec.EncryptingKeyIdentifier;
        }
        return true;
    }
    protected override bool TryResolveTokenCore(System.IdentityModel.Tokens.SecurityKeyIdentifierClause keyIdentifierClause, out System.IdentityModel.Tokens.SecurityToken token)
    {
        throw new NotImplementedException();
    }
    protected override bool TryResolveTokenCore(System.IdentityModel.Tokens.SecurityKeyIdentifier keyIdentifier, out System.IdentityModel.Tokens.SecurityToken token)
    {
        throw new NotImplementedException();
    }}
