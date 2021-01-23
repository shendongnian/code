    public void InspectSignatures(String path) {
	    Console.WriteLine(path);
        PdfReader reader = new PdfReader(path);
        AcroFields fields = reader.AcroFields;
        List<String> names = fields.GetSignatureNames();
        SignaturePermissions perms = null;
	    foreach (String name in names) {
		    Console.WriteLine("===== " + name + " =====");
		    perms = InspectSignature(fields, name, perms);
	    }
	    Console.WriteLine();
    }
