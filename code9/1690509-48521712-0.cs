	public static class TimeStampTokenHelper
	{
		public static IEnumerable<SignedData> GetTimeStampTokensAsSignedData(byte[] input)
		{
			var cmsInputStream = new Asn1InputStream(input);
			var asn1Object = cmsInputStream.ReadObject();
			Assert.IsNotNull(asn1Object);
			var rootSequence = Asn1Sequence.GetInstance(asn1Object);
			var signedData = GetSignedData(rootSequence);
			return GetTimeStampTokensFromSignedData(signedData);
		}
		private static SignedData GetSignedData(Asn1Sequence sequence)
		{
			var rootContent = ContentInfo.GetInstance(sequence);
			Assert.That(rootContent.ContentType.Id, Is.EqualTo("1.2.840.113549.1.7.2")); // signedData
			var signedData = SignedData.GetInstance(rootContent.Content);
			return signedData;
		}
		private static IEnumerable<SignedData> GetTimeStampTokensFromSignedData(SignedData signedData)
		{
			return GetTimeStampTokensFromSignerInfos(signedData.SignerInfos);
		}
		private static IEnumerable<SignedData> GetTimeStampTokensFromSignerInfos(Asn1Set signerInfos)
		{
			var timestampTokens = signerInfos
				.OfType<Asn1Sequence>()
				.SelectMany(GetTimeStampTokensFromSignerInfo);
			return timestampTokens;
		}
		private static IEnumerable<SignedData> GetTimeStampTokensFromSignerInfo(Asn1Sequence signerInfoSequence)
		{
			var signerInfo = SignerInfo.GetInstance(signerInfoSequence);
			var result = signerInfo.UnauthenticatedAttributes.ToArray()
				.Select(Asn1Sequence.GetInstance)
				.Where(x => ((DerObjectIdentifier)x.GetObjectAt(0)).Id == "1.2.840.113549.1.9.16.2.14")
				.Select(x => GetSignedData(Asn1Sequence.GetInstance(Asn1Set.GetInstance(x.GetObjectAt(1)).GetObjectAt(0))));
			return result;
		}
