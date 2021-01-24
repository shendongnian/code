    public class MainWindowViewModel : INotifyPropertyChanged
        {
    
            public MainWindowViewModel()
            {
                DGCollections = new ObservableCollection<DGCollection>();
                LoadData();
            }
    
            private ObservableCollection<DGCollection> _DGCollections;
    
            public ObservableCollection<DGCollection> DGCollections
            {
                get { return _DGCollections; }
                set
                {
                    _DGCollections = value;
                    NotifyPropertyChanged("DGCollections");
                }
            }
    
            private void LoadData()
            {
                KeyValues obj1 = new KeyValues { Key = "A", Value = "123" };
                KeyValues obj2 = new KeyValues { Key = "B", Value = "456" };
                KeyValues obj3 = new KeyValues { Key = "C", Value = "789" };
                KeyValues obj4 = new KeyValues { Key = "D", Value = "101112" };
                List<KeyValues> lst = new List<KeyValues>();
                lst.Add(obj1);
                lst.Add(obj2);
                lst.Add(obj3);
                lst.Add(obj4);            
                DGCollections.Add(new DGCollection { ID = 1, KeyValues = lst });
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(String info)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
            }
    
        }
