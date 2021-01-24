    var oWord = new Word.Application();
    oWord.Visible = true;                       
    var oDoc = oWord.Documents.Add();
    var math = oDoc.OMaths;
    
    for (int i = 1; i <= 10; i++)
    {
    	oDoc.Paragraphs.Add();
    	var para = oDoc.Paragraphs[i];
    	var paraRange = para.Range;
    	paraRange.Text = "x^2 + " + i + " = y";
    	math.Add(paraRange);
    }
    math.BuildUp();
    oWord.Quit();
