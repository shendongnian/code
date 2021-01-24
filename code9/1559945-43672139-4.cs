    public PDFSigning(byte[] Content, string UserName)
        {
            content = Content;
            reader = new PdfReader(content);
            ms = new MemoryStream();
            stamper = PdfStamper.CreateSignature(reader, ms, '\0');
            appearance = stamper.SignatureAppearance;
            userName = UserName;
        }
    private Stream getCertificate()
        {
            return new MemoryStream(Convert.FromBase64String("************************=="));
        }
