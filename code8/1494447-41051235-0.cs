    public void OpenGeodatabase()
    {
        Geodatabase gdb = null;
        // path to .geodatabase
        var gdbPath = @"..\..\..\test.geodatabase";
        // wrap OpenAsync call in Task
        Task.Run(async () =>
        {
            // open a geodatabase on the local device
            gdb = await Geodatabase.OpenAsync(gdbPath);
        }).Wait();
        // get the first geodatabase feature table
        var gdbFeatureTable = gdb.FeatureTables.FirstOrDefault();
        // create a layer for the feature table
        var lyr = new FeatureLayer
        {
            ID = gdbFeatureTable.Name,
            DisplayName = gdbFeatureTable.Name,
            FeatureTable = gdbFeatureTable
        };
        // add the graphics to the map
        MyMapView.Map.Layers.Add(lyr);
        // remove the layer - to make it similar to case explanation
        MyMapView.Map.Layers.Remove(lyr);
        // make gdb reference null
        gdb = null;
        gdbFeatureTable = null;
        lyr = null;
        
        // call garbage collector
        GC.Collect();
        GC.WaitForPendingFinalizers();
        // If the works, the lock has been removed
        System.IO.File.Delete(@"..\..\..\test.geodatabase");
    }
