    public class MVObjectManager
    {
        public ObservableCollection<MVDragableObject> ListObjects { get; set; }
        public MVObjectManager()
        {
            ListObjects = new ObservableCollection<MVDragableObject>();
        }
    }
    public class MVDragableObject
    {
    }
