    public void sign(String src, String dest,
                 Certificate[] chain,
                 PrivateKey pk, String digestAlgorithm, String provider,
                 PdfSigner.CryptoStandard subfilter,
                 String reason, String location)
        throws GeneralSecurityException, IOException {
    // Creating the reader and the signer
    PdfReader reader = new PdfReader(src);
    PdfSigner signer = new PdfSigner(reader, new FileOutputStream(dest), false);
    // Creating the appearance
    PdfSignatureAppearance appearance = signer.getSignatureAppearance()
            .setReason(reason)
            .setLocation(location)
            .setReuseAppearance(false);
    Rectangle rect = new Rectangle(36, 648, 200, 100);
    appearance
            .setPageRect(rect)
            .setPageNumber(1);
    signer.setFieldName("sig");
    // Creating the signature
    IExternalSignature pks = new PrivateKeySignature(pk, digestAlgorithm, provider);
    IExternalDigest digest = new BouncyCastleDigest();
    signer.signDetached(digest, pks, chain, null, null, null, 0, subfilter);
    }
