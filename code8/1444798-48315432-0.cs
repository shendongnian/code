    // Get signature description (using signature method algorithm http://www.w3.org/2001/04/xmldsig-more#rsa-sha256)
    var signatureDescription
      = System.Security.Cryptography.CryptoConfig.CreateFromName(System.Security.Cryptography.Xml.SignedXml.XmlDsigRSASHA256Url) as System.Security.Cryptography.SignatureDescription;
    if (signatureDescription == null)
      throw new System.Security.Cryptography.CryptographicException("SignatureDescriptionNotCreated");
    // Get hash algorithm from signature description
    System.Security.Cryptography.HashAlgorithm hashAlg = signatureDescription.CreateDigest();
    if (hashAlg == null)
      throw new System.Security.Cryptography.CryptographicException("CreateHashAlgorithmFailed");
    // Load SignedInfo OuterXml in a separate XmlDocument, and canonicalize
    var doc = new System.Xml.XmlDocument();
    string toBeCanonicalized = signedInfoTag.OuterXml;
    doc.LoadXml(toBeCanonicalized);
    var transform = new System.Security.Cryptography.Xml.XmlDsigExcC14NTransform();
    transform.LoadInput(doc);
    byte[] hashvalue = transform.GetDigestedOutput(hashAlg);  // hashvalue is not used, but I
                                                              // think this process allows to
                                                              // use hashAlg to get the
                                                              // SignatureValue later
    // Create signature formatter using certificate's private key
    System.Security.Cryptography.AsymmetricSignatureFormatter asymmetricSignatureFormatter
      = signatureDescription.CreateFormatter(mCertificate.PrivateKey);
    // Get signature value
    byte[] signatureValueBytes = asymmetricSignatureFormatter.CreateSignature(hashAlg);
    // Set signature value to node text, as Base64 string
    signValueTag.InnerText = Convert.ToBase64String(signatureValueBytes)
