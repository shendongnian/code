    public override string GetIssuerName( SecurityToken securityToken )
    {
        X509SecurityToken x509Token = securityToken as X509SecurityToken;
 
        if ( accept the cert ? )
           return x509Token.Certificate.Subject;
        else
           return string.Empty; // rejects it
    }
