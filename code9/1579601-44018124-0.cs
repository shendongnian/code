	public static byte[] ConstructEcdsaSigValue(byte[] rs)
	{
		if (rs == null)
			throw new ArgumentNullException(nameof(rs));
		if (rs.Length < 2 || rs.Length % 2 != 0)
			throw new ArgumentException("Invalid length", nameof(rs));
		int halfLen = rs.Length / 2;
		byte[] half1 = new byte[halfLen];
		Array.Copy(rs, 0, half1, 0, halfLen);
		var r = new Org.BouncyCastle.Math.BigInteger(1, half1);
		byte[] half2 = new byte[halfLen];
		Array.Copy(rs, halfLen, half2, 0, halfLen);
		var s = new Org.BouncyCastle.Math.BigInteger(1, half2);
		var derSequence = new Org.BouncyCastle.Asn1.DerSequence(
			new Org.BouncyCastle.Asn1.DerInteger(r),
			new Org.BouncyCastle.Asn1.DerInteger(s));
		return derSequence.GetDerEncoded();
	}
