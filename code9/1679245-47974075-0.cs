    			X509Certificate2 certificate = null;
			X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);
			my.Open(OpenFlags.ReadOnly);
			certificate = my.Certificates.Find(X509FindType.FindByThumbprint, "thumbprint", false)[0];
			var privKey = DotNetUtilities.GetRsaKeyPair(certificate.GetRSAPrivateKey()).Private;
			var cert = DotNetUtilities.FromX509Certificate(certificate);
			var content = new CmsProcessableByteArray(data);
			var generator = new CmsSignedDataGenerator();
			generator.AddSigner(privKey, cert, CmsSignedGenerator.EncryptionRsa, CmsSignedGenerator.DigestSha256);
			var signedContent = generator.Generate(content, false);
			string hashOid = OID.SHA256;
			var si = signedContent.GetSignerInfos();
			var signer = si.GetSigners().Cast<SignerInformation>().First();
			SignerInfo signerInfo = signer.ToSignerInfo();
			Asn1EncodableVector digestAlgorithmsVector = new Asn1EncodableVector();
			digestAlgorithmsVector.Add(
				new AlgorithmIdentifier(
					algorithm: new DerObjectIdentifier(hashOid),
					parameters: DerNull.Instance));
			// Construct SignedData.encapContentInfo
			ContentInfo encapContentInfo = new ContentInfo(
				contentType: new DerObjectIdentifier(OID.PKCS7IdData),
				content: null);
			Asn1EncodableVector certificatesVector = new Asn1EncodableVector();
			certificatesVector.Add(X509CertificateStructure.GetInstance(Asn1Object.FromByteArray(cert.GetEncoded())));
			// Construct SignedData.signerInfos
			Asn1EncodableVector signerInfosVector = new Asn1EncodableVector();
			signerInfosVector.Add(signerInfo.ToAsn1Object());
			// Construct SignedData
			SignedData signedData = new SignedData(
				digestAlgorithms: new DerSet(digestAlgorithmsVector),
				contentInfo: encapContentInfo,
				certificates: new BerSet(certificatesVector),
				crls: null,
				signerInfos: new DerSet(signerInfosVector));
			ContentInfo contentInfo = new ContentInfo(
				contentType: new DerObjectIdentifier(OID.PKCS7IdSignedData),
				content: signedData);
			return contentInfo.GetDerEncoded();
