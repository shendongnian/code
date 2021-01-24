    void Main()
    {
    	var vApp = MyExtensions.GetRunningVisio();
    	DropImage(vApp.ActivePage, @"C:\SomeImage.jpg");
    }
    
    private void DropImage(Visio.Page vPag, string imageFile)
    {
    	if (vPag != null)
    	{
    		var shpNew = vPag.Import(imageFile);
    		//Set position
    		shpNew.CellsU["PinX"].FormulaU = "75mm";
    		shpNew.CellsU["PinY"].FormulaU = "175mm";
    		//Set size
    		shpNew.CellsU["Width"].FormulaU = "100mm";
    		shpNew.CellsU["Height"].FormulaU = "80mm";
    	}
    }
