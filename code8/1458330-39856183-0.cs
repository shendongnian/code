    void Main()
    {
    	var vApp = MyExtensions.GetRunningVisio();
    	
    	Visio.Page vPag = vApp.ActivePage;
    	var q = from s in vPag.Shapes.Cast<Visio.Shape>()
    			where s.OneD == 0
    			orderby s.CellsU["Height"].ResultIU
    			select s.Text;
    	q.Dump();
    }
