	/// <summary>
	/// Imports certificate into the PKCS#11 compatible device
	/// </summary>
	/// <param name="session">Session with user logged in</param>
	/// <param name="certificate">Certificate that should be imported</param>
	/// <param name="ckaLabel">Value of CKA_LABEL attribute</param>
	/// <param name="ckaId">Value of CKA_ID attribute</param>
	/// <returns>Handle of created certificate object</returns>
	public static ObjectHandle ImportCertificate(Session session, byte[] certificate, string ckaLabel, byte[] ckaId)
	{
		// Parse certificate
		X509CertificateParser x509CertificateParser = new X509CertificateParser();
		X509Certificate x509Certificate = x509CertificateParser.ReadCertificate(certificate);
		// Define attributes of new certificate object
		List<ObjectAttribute> certificateAttributes = new List<ObjectAttribute>();
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_CERTIFICATE));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_TOKEN, true));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_PRIVATE, false));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_MODIFIABLE, true));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_LABEL, ckaLabel));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_CERTIFICATE_TYPE, CKC.CKC_X_509));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_TRUSTED, false));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_SUBJECT, x509Certificate.SubjectDN.GetDerEncoded()));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_ID, ckaId));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_ISSUER, x509Certificate.IssuerDN.GetDerEncoded()));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_SERIAL_NUMBER, new DerInteger(x509Certificate.SerialNumber).GetDerEncoded()));
		certificateAttributes.Add(new ObjectAttribute(CKA.CKA_VALUE, x509Certificate.GetEncoded()));
		// Create certificate object
		return session.CreateObject(certificateAttributes);
	}
