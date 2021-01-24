    void Main()
    {
    	var vApp = MyExtensions.GetRunningVisio();
    
    	var sourcePage = vApp.ActivePage;
    	var sourceDoc = sourcePage.Document;
    	var vSel = sourcePage.CreateSelection(Visio.VisSelectionTypes.visSelTypeAll);
    	vSel.Copy(Visio.VisCutCopyPasteCodes.visCopyPasteNoTranslate);
    
    	var copyDoc = vApp.Documents.AddEx(string.Empty,
    						 Visio.VisMeasurementSystem.visMSDefault,
    						 (int)Visio.VisOpenSaveArgs.visAddHidden);
    	copyDoc.Pages[1].Paste(Visio.VisCutCopyPasteCodes.visCopyPasteNoTranslate);
    	
    	var origFileName = sourceDoc.FullName;
    	var newFileName = Path.Combine(sourceDoc.Path, $"LastStored{Path.GetExtension(origFileName)}");
    	copyDoc.SaveAs(newFileName);
    	copyDoc.Close();
    }
