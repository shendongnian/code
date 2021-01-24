    private static CngKey GetPrivateKey()
    {
        using (var reader = File.OpenText("path/to/apns/auth/key/file.p8"))
        {
            var ecPrivateKeyParameters = (ECPrivateKeyParameters)new PemReader(reader).ReadObject();
            var x = ecPrivateKeyParameters.Parameters.G.AffineXCoord.GetEncoded();
            var y = ecPrivateKeyParameters.Parameters.G.AffineYCoord.GetEncoded();
            var d = ecPrivateKeyParameters.D.ToByteArrayUnsigned();
            return EccKey.New(x, y, d);
        }
    }
