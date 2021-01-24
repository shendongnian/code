    public class MyClass : BaseViewModel
    {
        public System.Collections.ObjectModel.ObservableCollection<string> MyCollection
        {
            get;
        }
        public MyClass()
        {
            MyCollection = new System.Collections.ObjectModel.ObservableCollection<string>();
            MyCollection.CollectionChanged += MyCollection_CollectionChanged;
        }
        public bool IsEmpty
        {
            get
            {
                return MyCollection.Count == 0;
            }
        }
        public void RefillMyCollection(IEnumerable<string> values)
        {
            MyCollection.Clear();
            foreach(string value in values)
            {
                MyCollection.Add(value);
            }
        }
        private void MyCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("IsEmpty");
        }
        
    }
