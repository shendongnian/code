    private void GetAndPlotData(List<Action<object>> actionPlotData)
    {
        for (int ok = 0; ok < 10000000; ok++)
        {
            // Get some data
            double[][] testData = new double[2][];
            testData[0] = new double[] { 1, 2, 3, 4 };
            testData[1] = new double[] { 2, 4, 6, 8 };
            // Plot it
            // QUESTION - how to reference passed List of Graphs in the loop?
            for (int i = 0; i < actionPlotData.Count; i++)
            {
                Dispatcher.BeginInvoke(actionPlotData[i], new object[] { testData[i] });
            }
            Thread.Sleep(10);
        }
    }
    private async void StartTest()
    {
        // QUESTION -  how to pass List Of Graphs as an Action to loop through them later on?
        await Task.Run(() => GetAndPlotData( new List<Action<object>> { 
            data => Graphs[0].DataSource = data,
            data2 => Graphs[1].DataSource = data2
            });
    }
