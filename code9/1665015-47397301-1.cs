    void Main()
    {
    	var vApp = MyExtensions.GetRunningVisio();
    	var vPag = vApp.ActivePage;
    	foreach (Visio.Shape shp in vPag.Shapes)
    	{
    		Console.WriteLine($"Text: {shp.Text} \nCharacters: {shp.Characters.Text}\n");
    	}
    }
