    PdfReader pdfReader = new PdfReader(pdfTemplate);
    PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create), '\0', true);
    AcroFields pdfFormFields = pdfStamper.AcroFields;
    pdfFormFields.SetField("4a.0", "1"); // radio button
    pdfFormFields.SetField("4a.1", "1"); // checkbox
    pdfFormFields.SetFieldProperty("4a.1", "clrflags", 2, null);
    pdfFormFields.SetField("4a.2", "2010"); // text box 
    pdfFormFields.SetFieldProperty("4a.2", "clrflags", 2, null);
    pdfStamper.Close();
