			// create DN for subject and issuer
			var dn = new CX500DistinguishedName();
			dn.Encode("CN=localhost");
			// create a new private key for the certificate
			var privateKey = new CX509PrivateKey
			{
				ProviderName = "Microsoft Base Cryptographic Provider v1.0",
				MachineContext = true,
				Length = 2048,
				KeySpec = X509KeySpec.XCN_AT_SIGNATURE,
				KeyUsage = X509PrivateKeyUsageFlags.XCN_NCRYPT_ALLOW_ALL_USAGES,
				FriendlyName = "App Testing Key",
				ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_EXPORT_FLAG
			};
			privateKey.Create();
			var hashobj = new CObjectId();
			hashobj.InitializeFromAlgorithmName(ObjectIdGroupId.XCN_CRYPT_HASH_ALG_OID_GROUP_ID,
				ObjectIdPublicKeyFlags.XCN_CRYPT_OID_INFO_PUBKEY_ANY,
				AlgorithmFlags.AlgorithmFlagsNone, "SHA256");
			// Create the self signing request
			// also see: https://security.stackexchange.com/a/103362
			var certificateRequest = new CX509CertificateRequestCertificate();
			certificateRequest.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextMachine, privateKey, String.Empty);
			certificateRequest.Subject = dn;
			certificateRequest.Issuer = dn; // the issuer and the subject are the same
			certificateRequest.NotBefore = DateTime.UtcNow.AddDays(-1);
			certificateRequest.NotAfter = DateTime.UtcNow.AddYears(10);
			certificateRequest.HashAlgorithm = hashobj;
			// Set up the Subject Alternative Names extension.
			var nameslist = new CAlternativeNames();
			var alternativeName = new CAlternativeName();
			alternativeName.InitializeFromString(AlternativeNameType.XCN_CERT_ALT_NAME_DNS_NAME, "localhost");
			nameslist.Add(alternativeName);
			var subjectAlternativeNamesExtension = new CX509ExtensionAlternativeNames();
			subjectAlternativeNamesExtension.InitializeEncode(nameslist);
			certificateRequest.X509Extensions.Add((CX509Extension)subjectAlternativeNamesExtension);
			var skiExtension = new CX509ExtensionSubjectKeyIdentifier();
			skiExtension.InitializeEncode(EncodingType.XCN_CRYPT_STRING_BASE64, Convert.ToBase64String(StringToByteArray(certSKI)));
			certificateRequest.X509Extensions.Add((CX509Extension)skiExtension);
			certificateRequest.Encode();
			// Do the final enrollment process
			var enroll = new CX509Enrollment();
			enroll.InitializeFromRequest(certificateRequest); // load the certificate
			enroll.CertificateFriendlyName = "App Testing Cert";
			var csr = enroll.CreateRequest(); // Output the request in base64
			var pwd = Guid.NewGuid().ToString();
			enroll.InstallResponse(InstallResponseRestrictionFlags.AllowUntrustedCertificate, csr, EncodingType.XCN_CRYPT_STRING_BASE64, pwd); // and install it back as the response
			var base64encoded = enroll.CreatePFX(pwd, PFXExportOptions.PFXExportChainWithRoot);
			// instantiate the target class with the PKCS#12 data 
			return new X509Certificate2(Convert.FromBase64String(base64encoded), pwd, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
