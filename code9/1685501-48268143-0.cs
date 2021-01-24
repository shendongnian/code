    private void setUserSelection(Chart cht)
    {
    	cht.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
    	cht.ChartAreas[0].CursorX.IsUserEnabled = true;
    	cht.ChartAreas[0].CursorX.LineColor = Color.Transparent;
    	cht.ChartAreas[0].CursorX.SelectionColor = Color.Lime;
    	cht.ChartAreas[0].CursorX.Interval = 0;
    	cht.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
    	cht.ChartAreas[0].AxisX2.ScaleView.Zoomable = true;
    
    	cht.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
    	cht.ChartAreas[0].CursorY.IsUserEnabled = true;
    	cht.ChartAreas[0].CursorY.LineColor = Color.Transparent;
    	cht.ChartAreas[0].CursorY.SelectionColor = Color.Lime;
    	cht.ChartAreas[0].CursorY.Interval = 0;
    	cht.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
    	cht.ChartAreas[0].AxisY2.ScaleView.Zoomable = true;
    }
