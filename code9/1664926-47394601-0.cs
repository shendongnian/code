    private void MakeData()
        {
            List<string> allValues = new List<string>();
            var NameLables = new List<string>();
            //Simulate the SQL query by looping over X times
            for (int i = 0; i < 5; i++)
            {
                allValues.Add((i + 1).ToString());
                NameLables.Add(DateTime.Today.AddDays(i).ToString("dd-MM-yyyy"));
            }
            seriesCol = new SeriesCollection();
            
            seriesCol.AddRange(Enumerable.Range(0, allValues.Count).Select(x => new PieSeries { Title = NameLables[x], Values = new ChartValues<ObservableValue> { new ObservableValue(double.Parse(allValues[x])) } }));
        }
