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
    
        GraphInput.Add(time, IncomingData); // add to list
        GraphInput2.Add(time, IncomingData2); // add to list
    	
    	// AT THIS POINT YOU COULD SEARCH THROUGH THE POINT LIST & REMOVE ANY POINTS PRIOR TO THE MIN TIME
        while (GraphInput[0].X < myPane.XAxis.Min)
        {
          GraphInput.RemoveAt(0);
        }
        while (GraphInput2[0].X < myPane.XAxis.Min)
        {
          GraphInput2.RemoveAt(0);
        }
        zgc.AxisChange(); // update axis
        zgc.Refresh();
    } 
