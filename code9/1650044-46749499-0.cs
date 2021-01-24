    private void button1_Click(object sender, EventArgs e)
    {
        Document wordDocument = ....;/// Your code to open document
    
        if(HasContentControlWithTitle(wordDocument, "something2"))
        {
            NotepadFile.Write("blabla2");
        }
        if(HasContentControlWithTitle(wordDocument, "something1"))
        {
            NotepadFile.Write("blabla1");
        }
        if(HasContentControlWithTitle(wordDocument, "something3"))
        {
            NotepadFile.Write("blabla3");
        }
    }
    
    bool HasContentControlWithTitle(Document wordDocument, string title)
    {
        ContentControl result = GetContentControlByTitle(wordDocument, title);
        return result != null;
    }
    
    ContentControl GetContentControlByTitle(Document wordDocument, string title)
    {
        ContentControl result = null;
    
        foreach(ContentControl ff in wordDocument.ContentControls)
        {
            if(ff.Title == title)
            {
                result = ff;
                break;
            }
        }
    
        return result;
    }
