        int _xValue = 0;
        public void dispatcherTimer_Tick(object sender, EventArgs e)
        { 
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                LineSeries ser = plotModel.Series[0] as LineSeries;
                if (ser != null)
                {
                    // check your conditions and caclulate the Y value of the point
                    double yValue = 1;
                    ser.Points.Add(new DataPoint(_xValue, yValue));
                    _xValue++;
                } 
                if (ser.Points.Count > 80) //show only 10 last points
                    ser.Points.RemoveAt(0); //remove first point
                plotModel.InvalidatePlot(true);
            });
        }
