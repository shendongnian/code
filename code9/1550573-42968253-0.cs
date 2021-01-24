    const string FILE_IMAGE = @"C:\Users\BabyboB\Documents\google.png";
    	const string FILE_DOCX = @"C:\Users\BabyboB\Documents\testingdoc.docx";
    	
    	var app = new MsWord.Application();
    	MsWord.Document doc = null;
    
    	try
    	{
    		doc = app.Documents.Open(FILE_DOCX, Type.Missing);
    		var testingCtrls = doc.SelectContentControlsByTag("testing");
    
    		//assuming image jas to be added to 1st control in testingCtrls
    		//it should be a content control which allows picture in it.
    		//e.g. wdContentControlRichText or wdContentControlPicture.
    		var testingCtrl = testingCtrls[1];
    		testingCtrl.Range.InlineShapes.AddPicture(FILE_IMAGE, Type.Missing, Type.Missing, Type.Missing);
    
    		doc.Save();
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
