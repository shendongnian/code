    void Main()
    {
    	var vApp = MyExtensions.GetRunningVisio();
    	
    	var sourcePage = vApp.ActivePage;
    	var sourcePageNameU = sourcePage.NameU;
    	var vDoc = sourcePage.Document;
    	vDoc.Save(); //to retain original
    	var origFileName = vDoc.FullName;
    	
    	var newFileName = Path.Combine(vDoc.Path, $"LastStored{Path.GetExtension(origFileName)}");
    	vDoc.SaveAs(newFileName);
    	
    	//Remove all other pages
    	for (short i = vDoc.Pages.Count; i > 0; i--)
    	{
    		if (vDoc.Pages[i].NameU != sourcePageNameU)
    		{
    			vDoc.Pages[i].Delete(0);
    		}
    	}
    	
    	//Save single page state
    	vDoc.Save();
    	
    	//Close copy and reopen original
    	vDoc.Close();
    	vDoc = vApp.Documents.Open(origFileName);
    }
