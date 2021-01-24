     public Saml2SecurityToken DeserializeSAMLResponse(string samlResponse)
        {
            //Deserializing saml response
            Saml2SecurityToken token;
            using (var reader = XmlReader.Create(new StringReader(samlResponse)))
            {
                reader.ReadToFollowing("Assertion", Infrastructure.Enumerations.StringEnum.GetStringValue(SAMLProtocoles.SAML_20_ASSERTION));
                // Deserialize the token so that data can be taken from it and plugged into the RSTR
                SecurityTokenHandlerCollection tokenHandlerCollection = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection();
                token = (Saml2SecurityToken)tokenHandlerCollection.ReadToken(reader.ReadSubtree());
            }
            //Deserializing successful
            return token;
        }
