	public virtual void InspectSignatures(String path)
	{
		// System.out.println(path);
		PdfDocument pdfDoc = new PdfDocument(new PdfReader(path));
		PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, false);
		SignaturePermissions perms = null;
		SignatureUtil signUtil = new SignatureUtil(pdfDoc);
		IList<String> names = signUtil.GetSignatureNames();
		foreach (String name in names)
		{
			System.Console.Out.WriteLine("===== " + name + " =====");
			perms = InspectSignature(pdfDoc, signUtil, form, name, perms);
		}
		System.Console.Out.WriteLine();
	}
