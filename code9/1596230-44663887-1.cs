    public class Test
    {
        string _id;
        public ObservableCollection<DataElement> PartData { get; set; }
        public ObservableCollection<DataElement> SensorData { get; set; }
        // just to have one additional property that will not be part of the returned document
        public string TestString { get; set; }
    }
    
    public class DataElement
    {
    }
