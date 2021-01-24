    internal static (string x, string y) GetCertificateCoordinates(byte[] publicKeyBytes)
    {
        // parse based on asn1 format the content of the certificate
        var asn1 = (Asn1Sequence)Asn1Object.FromByteArray(publicKeyBytes);
        var at1 = (DerBitString)asn1[1];
        var xyBytes = at1.GetBytes();
            
        //retrieve preddefined parameters for P256 curve
        X9ECParameters x9 = ECNamedCurveTable.GetByName("P-256");
        //establish domain we will be looking for the x and y
        ECDomainParameters domainParams = new ECDomainParameters(x9.Curve, x9.G, x9.N, x9.H, x9.GetSeed());
        ECPublicKeyParameters publicKeyParams = new ECPublicKeyParameters(x9.Curve.DecodePoint(xyBytes), domainParams);
        //get the affine x and y coordinates
        var affineX = EncodeCordinate(publicKeyParams.Q.AffineXCoord.ToBigInteger());
        var affineY = EncodeCordinate(publicKeyParams.Q.AffineYCoord.ToBigInteger());
        return (affineX, affineY);
    }
    public static string EncodeCordinate(Org.BouncyCastle.Math.BigInteger integer)
    {
        var notPadded = integer.ToByteArray();
        int bytesToOutput = (256 + 7) / 8;
        if (notPadded.Length >= bytesToOutput)
            return Jose.Base64Url.Encode(notPadded);
        var padded = new byte[bytesToOutput];
        Array.Copy(notPadded, 0, padded, bytesToOutput - notPadded.Length, notPadded.Length);
        return Jose.Base64Url.Encode(padded);
    }
