    public class MyViewModel
    {
        public ObservableCollection<MyObject> MyObjectCollection { get; set;}
    }
    public class MyObject
    {
        public string ObjectName {get; set;}
        public ObservableCollection<AnotherObject> AnotherObjectCollection { get; set; }
    }
