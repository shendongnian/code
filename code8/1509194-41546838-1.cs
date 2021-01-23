    public class ViewModel
    {
        public ViewModel()
        {
            TheDataObjects = new ObservableCollection<YourDataObject>();
            TheDataObjects.Add(new YourDataObject());
            TheDataObjects.Add(new YourDataObject());
            TheDataObjects.Add(new YourDataObject());
        }
        public ObservableCollection<YourDataObject> TheDataObjects { get; private set; }
    }
