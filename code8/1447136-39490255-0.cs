    public static byte[] GetBytesToSign(string unsignedPdf, string tempPdf, string signatureFieldName)
    {
    	using (PdfReader reader = new PdfReader(unsignedPdf))
    	{
    		using (FileStream os = File.OpenWrite(tempPdf))
    		{
    			PdfStamper stamper = PdfStamper.CreateSignature(reader, os, '\0');
    			PdfSignatureAppearance appearance = stamper.SignatureAppearance;
    			appearance.SetVisibleSignature(new Rectangle(36, 748, 144, 780), 1, signatureFieldName);
    			IExternalSignatureContainer external = new ExternalBlankSignatureContainer(PdfName.ADOBE_PPKMS, PdfName.ADBE_PKCS7_SHA1);
    			MakeSignature.SignExternalContainer(appearance, external, 8192);
    
    			return SHA1Managed.Create().ComputeHash(appearance.GetRangeStream());
    		}
    	}
    }
    public static void EmbedSignature(string tempPdf, string signedPdf, string signatureFieldName, byte[] signedBytes)
    {
    	using (PdfReader reader = new PdfReader(tempPdf))
    	{
    		using (FileStream os = File.OpenWrite(signedPdf))
    		{
    			IExternalSignatureContainer external = new MyExternalSignatureContainer(signedBytes);
    			MakeSignature.SignDeferred(reader, signatureFieldName, os, external);
    		}
    	}
    }
    
    private class MyExternalSignatureContainer : IExternalSignatureContainer
    {
    	private readonly byte[] signedBytes;
    
    	public MyExternalSignatureContainer(byte[] signedBytes)
    	{
    		this.signedBytes = signedBytes;
    	}
    
    	public byte[] Sign(Stream data)
    	{
    		return signedBytes;
    	}
    
    	public void ModifySigningDictionary(PdfDictionary signDic)
    	{
    	}
    }
