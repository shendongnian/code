     private void InitGraph1 (ZedGraphControl zgc)
            {
                GraphPane myPane = zgc.GraphPane; // setup graph
    
                zgc.AutoScroll = true;
                myPane.Title = "Graph 1"; // Titles 
                myPane.XAxis.Title = "Time (s)";
                myPane.YAxis.Title = "";
                myPane.Legend.IsVisible = false; // remove legend
    
                GraphInput1 = new PointPairList(); // create a new list
                GraphInput2 = new PointPairList(); // create a new list
                myCurve = myPane.AddCurve(DataOutputZ, GraphInput1, Color.Red, SymbolType.Diamond); // draw points
                myCurve2 = myPane.AddCurve(DataOutputY, GraphInput2, Color.Blue, SymbolType.Diamond);
                  
             }
-
     private void UpdateGraph(ZedGraphControl zgc, long time, int IncomingData, int IncomingData2)
            {
                {
                    GraphPane myPane = zgc.GraphPane;
                    myPane.XAxis.Min = time - GraphTimeSpan;
                    myPane.XAxis.Max = time + (GraphTimeSpan/4); // put new points in last quarter of graph
    
                    // Get the first CurveItem in the graph
                    LineItem myCurve = zgc.GraphPane.CurveList[0] as LineItem;
                    LineItem myCurve2 = zgc.GraphPane.CurveList[1] as LineItem;
    
                    PointPairList GraphInput1 = myCurve.Points as PointPairList;
                    PointPairList GraphInput2 = myCurve2.Points as PointPairList;
    
                    // add new data points to the graph
                    GraphInput1.Add(time, IncomingData);
                    GraphInput2.Add(time, IncomingData2);
    
                    while (GraphInput1[0].X < myPane.XAxis.Min)
                    {
                        GraphInput1.RemoveAt(0);
                    }
                    while (GraphInput2[0].X < myPane.XAxis.Min)
                    {
                        GraphInput2.RemoveAt(0);
                    }
    
                    // force redraw
                    zgc.Invalidate();
                    zgc.AxisChange(); // update axis
                    zgc.Refresh();
                }
            }
