    //convert from key to string
    SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
    byte[] serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();    
    string serializedPublic = Convert.ToBase64String(serializedPublicBytes);
    And then, i can convert the serializedPublic to RsaKeyParameters publicKey
    
    //convert from string to key
    RsaKeyParameters publicKey2 = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(serializedPublic));
