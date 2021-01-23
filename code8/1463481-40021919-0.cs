    PointPairList GraphInput;
    PointPairList GraphInput2;
    LineItem myCurve;
    LineItem myCurve2;
    
    private void InitGraph(ZedGraphControl zgc)
    {
        GraphPane myPane = zgc.GraphPane; // setup graph
    
        zgc.AutoScroll = true;
        myPane.Title = "Graph 1"; // Titles 
        myPane.XAxis.Title = "Time (s)"; 
        myPane.YAxis.Title = "";
        myPane.Legend.IsVisible = false; // remove legend (DONT MAKE TRUE!!)
    
        GraphInput = new PointPairList(); // create a new list
        GraphInput2 = new PointPairList(); // create a new list
        myCurve = myPane.AddCurve("FirstSettings", GraphInput, Color.Red, SymbolType.Diamond); // draw points
        myCurve2 = myPane.AddCurve("SecondSettings", GraphInput2, Color.Blue, SymbolType.Diamond);
    }
    
    private void UpdateGraph(ZedGraphControl zgc, long time, int IncomingData, int IncomingData2)
    {
    	GraphPane myPane = zgc.GraphPane; // setup graph
    
        myPane.XAxis.Max = time;
        myPane.XAxis.Min = myPane.XAxis.Max - GraphTimeSpan;
    
        long x;
        int y1;
        long x2;
        int y2;
        x = time; // x axis 1
        y1 = IncomingData; // y axis 1
        x2 = time; // x axis 2
        y2 = IncomingData2; // y axis 2
    
        GraphInput.Add(x, y1); // add to list
        GraphInput2.Add(x2, y2); // add to list
    	
    	// AT THIS POINT YOU COULD SEARCH THROUGH THE POINT LIST & REMOVE ANY POINTS PRIOR TO THE MIN TIME
    
        zgc.AxisChange(); // update axis
        zgc.Refresh();
    } 
