    X9ECParameters ecP = NistNamedCurves.GetByName("P-256");
    ECDomainParameters ecSpec = new ECDomainParameters(ecP.Curve, ecP.G, ecP.N, ecP.H, ecP.GetSeed());
    ECKeyPairGenerator g = new ECKeyPairGenerator();
    g.Init(new ECKeyGenerationParameters(ecSpec, new SecureRandom()));
    
    AsymmetricCipherKeyPair server = g.GenerateKeyPair();
    ECPublicKeyParameters serverPub = (ECPublicKeyParameters)server.Public;
    var result = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(serverPub).GetDerEncoded();
