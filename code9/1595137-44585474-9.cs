    public class MyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string>[] MyLists { get; set; }
        public MyModel()
        {
            MyLists = new List<string>[2];
            MyLists[0] = new List<string>() { "abc", "def", "ghi" };
            MyLists[1] = new List<string>() { "123", "456", "789" };
        }
        public void UpdateListsExample()
        {
            MyLists[0] = new List<string>() { "abc", "def", "ghi", "jkl" };
            MyLists[1] = new List<string>() { "123", "456" };
            NotifyPropertyChanged("MyLists");
        }
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
