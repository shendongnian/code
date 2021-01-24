    public class MyViewModel
    {
        public ObservableCollection<MyModel> models = new ObservableCollection<MyModel>();
        public MyViewModel()
        {
            models.CollectionChanged += Models_CollectionChanged;
        }
        private void Models_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object model in e.NewItems)
                {
                    (model as INotifyPropertyChanged).PropertyChanged
                        += new PropertyChangedEventHandler(Model_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (object model in e.OldItems)
                {
                    (model as INotifyPropertyChanged).PropertyChanged
                        -= new PropertyChangedEventHandler(Model_PropertyChanged);
                }
            }
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MyModel updatedModel = sender as MyModel;
            MyModel duplicate = models.FirstOrDefault(x => x != updatedModel && x.Data == updatedModel.Data);
            if(duplicate != null)
            {
                updatedModel.Data += "0";
            }
        }
    }
----------
    public class MyModel : INotifyPropertyChanged
    {
        private string _data;
        public string Data
        {
            get { return _data; }
            set { _data = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
