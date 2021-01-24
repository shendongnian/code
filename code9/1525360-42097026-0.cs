        public void OnDataAnalyzed(string data, int channelNumber)
        {
           // MessageBox.Show("Analyzed");
            Data.Clear();
            Data.Add(new MyData() { Year = 1, Value = Convert.ToInt32(data.Substring(7, 2)), WorkType = WorkTypes.Violet });
  
            Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action(() => BarChart1.CanChangeLegendVisibility = true));
        }
