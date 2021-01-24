    private void Output_Load(object sender, EventArgs e)
    {
        List<Graph> ObservingData = new List<Graph>(); // List to store all available Graph objects from the CSV
        // Loops through each lines in the CSV
        foreach (string line in System.IO.File.ReadAllLines(pathToCsv).Skip(1)) // .Skip(1) is for skipping header
        {
            // here line stands for each line in the csv file
            string[] InCsvLine = line.Split(',');
            // creating an object of type Graph based on the each csv line
            Graph Inst1 = new Graph();
            Inst1.Speed = double.Parse(InCsvLine[1]);
            Inst1.Distance= double.Parse(InCsvLine[2]);
            chart1.Series["Distance"].Points.AddXY(Inst1.Speed, Inst1.Distance);
            // you forgot to store the items:
            ObservingData.Add(Inst1);
        }
            // after the loop you can pull out the min and max values to adjust your axes:
            double min = ObservingData.Min(x=>x.Distance);
            double max = ObservingData.Maxn(x=>x.Distance);
            chart1.ChartAreas[0].AxisY.Minimum = min;
            chart1.ChartAreas[0].AxisY.Maximum = max;
            chart1.Series["Distance"].YAxisType = AxisType.Primary;
            chart1.Series["Distance"].ChartType = SeriesChartType.FastLine;
            ChartArea CA = chart1.ChartAreas[0];
            CA.AxisX.ScaleView.Zoomable = false;
            CA.AxisY.ScaleView.Zoomable = false;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;
    }
