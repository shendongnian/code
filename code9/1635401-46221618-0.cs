    /**
     * key generation test
     */
    [Test]
    public void TestECDsaKeyGenTest()
    {
        SecureRandom random = new SecureRandom();
        BigInteger n = new BigInteger("883423532389192164791648750360308884807550341691627752275345424702807307");
        FpCurve curve = new FpCurve(
            new BigInteger("883423532389192164791648750360308885314476597252960362792450860609699839"), // q
            new BigInteger("7fffffffffffffffffffffff7fffffffffff8000000000007ffffffffffc", 16), // a
            new BigInteger("6b016c3bdcf18941d0d654921475ca71a9db2fb27d1d37796185c2942c0a", 16), // b
            n, BigInteger.One);
        ECDomainParameters parameters = new ECDomainParameters(
            curve,
            curve.DecodePoint(Hex.Decode("020ffa963cdca8816ccc33b8642bedf905c3d358573d3f27fbbd3b3cb9aaaf")), // G
            n);
        ECKeyPairGenerator pGen = new ECKeyPairGenerator();
        ECKeyGenerationParameters genParam = new ECKeyGenerationParameters(
            parameters,
            random);
        pGen.Init(genParam);
        AsymmetricCipherKeyPair pair = pGen.GenerateKeyPair();
        ParametersWithRandom param = new ParametersWithRandom(pair.Private, random);
        ECDsaSigner ecdsa = new ECDsaSigner();
        ecdsa.Init(true, param);
        byte[] message = new BigInteger("968236873715988614170569073515315707566766479517").ToByteArray();
        BigInteger[] sig = ecdsa.GenerateSignature(message);
        ecdsa.Init(false, pair.Public);
        if (!ecdsa.VerifySignature(message, sig[0], sig[1]))
        {
            Fail("signature fails");
        }
    }
