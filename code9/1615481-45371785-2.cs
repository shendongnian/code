     public User GetUserFromToken(Saml2SecurityToken Token)
        {
            //Get user information from the token started
            User User = new User();
            if (Token != null)
            {
                if (Token.Assertion.Subject.NameId != null && (Token.Assertion.Subject.NameId.Format == null || Token.Assertion.Subject.NameId.Format.OriginalString == "urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress"))
                    User.EmailAddress = Token.Assertion.Subject.NameId.Value;
                foreach (var Statement in Token.Assertion.Statements)
                {
                    var AttributeStatement = Statement as Saml2AttributeStatement;
                    var AuthenticationStatement = Statement as Saml2AuthenticationStatement;
                    if (AttributeStatement != null)
                        foreach (var Saml2Attribute in AttributeStatement.Attributes)
                        {
                            if (Saml2Attribute.Name.Equals("mail") || Saml2Attribute.Name.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"))
                                User.EmailAddress = Saml2Attribute.Values[0];
                            if (Saml2Attribute.Name.Equals("uid") || Saml2Attribute.Name.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"))
                                User.Name = Saml2Attribute.Values[0];
                            if (Saml2Attribute.Name.Equals("phone"))
                                User.MobileNumber = Saml2Attribute.Values[0];
                            if (Saml2Attribute.Name.Equals("title"))
                                User.JobTitle = Saml2Attribute.Values[0];
                            if (Saml2Attribute.Name.Equals("company"))
                                User.CompanyName = Saml2Attribute.Values[0];
                        }
                    if (AuthenticationStatement != null)
                    {
                        User.SAMLSessionIndex = AuthenticationStatement.SessionIndex;
                    }
                }
            }
            //Successfully parsed user credentials
            return User;
        }
