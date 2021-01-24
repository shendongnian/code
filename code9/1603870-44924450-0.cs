       public class ViewModel
       {
        public ObservableCollection<TotalData> TotalDataColl { get; set; }
        public ChartViewModel ChartSeriesViewModel { get; set; }
        public ViewModel()
        {
            TotalDataColl = new ObservableCollection<TotalData>();
            ChartSeriesViewModel = new ChartViewModel
            {
                Series = new ObservableCollection<SeriesViewModel>
                {
                    new SeriesViewModel{type="Lemons", Items = new ObservableCollection<ItemViewModel>{new ItemViewModel{source = "January", value = 25}, new ItemViewModel{source = "February", value = 35}}},
                    new SeriesViewModel{type="Oranges",Items = new ObservableCollection<ItemViewModel>{new ItemViewModel{source = "January", value = 22}, new ItemViewModel{source = "February", value = 36}}}
                }
    
            };
        }
    
    }
