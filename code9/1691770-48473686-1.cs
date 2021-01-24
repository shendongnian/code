    private void ugTopActivity_ChartDataClicked(object sender, ChartDataEventArgs e)
    {
        var o = sender as MyChartClass; //Or whatever type it is
        if (o != null) 
        {
            var box = new Box(test);
            var sceneGraph = o.GetFillSceneGraph();  //Get the scene graph from the sender
            sceneGraph.Add(box);  //Add the box to the graph
        }
    }
    
