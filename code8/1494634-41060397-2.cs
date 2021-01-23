    public class MyViewModel
    {
        public ObservableCollection<KeyValuePair<DateTime,int>> MyGraph { get; set; }
        public MyViewModel()
        {
            MyGraph = new ObservableCollection<KeyValuePair<DateTime, int>>();
        }
    }
