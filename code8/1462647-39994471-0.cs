    [TestMethod]
    public void TestDateDisplayFormat()
    {
        Application word = new Application();
        Assert.IsNotNull(word);
        word.Visible = true;
        Document document = word.Documents.Add();
        var iControl = document.ContentControls.Add(Word.WdContentControlType.wdContentControlDate, document.Content);
        iControl.DateDisplayLocale = Word.WdLanguageID.wdEnglishUS;
        iControl.DateDisplayFormat = "MMM dd/yy";
        iControl.Tag = "Test";
        return; 
    }   
