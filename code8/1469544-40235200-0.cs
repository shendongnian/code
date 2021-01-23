    public class MyObservableCollection : ObservableCollection<Record> 
    {
        public MyObservableCollection()
        {
        }
        public MyObservableCollection(List<Record> originalEntityList)
            : base(originalEntityList)
        {
        }
    }
