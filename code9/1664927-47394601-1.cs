    private void MakeData2()
        {
            var temp = new SeriesCollection();
            for (int i = 0; i < 5; i++)
            {
                var dname = DateTime.Today.AddDays(i).ToString("dd-MM-yyyy");
                var qty = i;
                temp.Add(new PieSeries { Title = dname, Values = new ChartValues<ObservableValue> { new ObservableValue(qty) } });
            }
            seriesCol = temp;
        }
