        // a few short references:
        ChartArea ca = chart1.ChartAreas[0];
        Axis ax = ca.AxisX;
        var cx = ca.CursorX;
        
        cx.IsUserEnabled = true;             // allow a cursor to be placed
        cx.IsUserSelectionEnabled = true;    // alow it to be used for selecting
        ax.ScaleView.Zoomable = false;       // prevent from automatically zooming in
