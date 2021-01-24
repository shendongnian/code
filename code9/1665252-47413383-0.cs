    public class PersonsObservable<T> : ObservableCollection<Person> where T : INotifyPropertyChanged
        {
            
            private PersonsObservable<Person> _personslist;
            public PersonsObservable<Person> personslist
            {
                get { return _personslist; }
                set
                {
                    _personslist = value;
                    _personslist.CollectionChanged += OnObservableCollectionChanged; 
                }
            }
            public void OnObservableCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if(e.NewItems != null)
                {
                    foreach (object item in e.NewItems)
                        ((INotifyPropertyChanged)item).PropertyChanged += OnItemPropertyChanged;
                }
                if(e.OldItems != null)
                {
                    foreach (object item in e.OldItems)
                        ((INotifyPropertyChanged)item).PropertyChanged -= OnItemPropertyChanged;
                }
            }
            public void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, IndexOf((Person)sender));
                OnCollectionChanged(args);
            }
             
        }
        public class Person : INotifyPropertyChanged
        {
            public Person()
            {
                _name = "Walter White";
                _age = 40;
                _height = 180;
            }
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            private string _name;
            public string name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                    this.OnPropertyChanged();
                }
            }
            private int _age;
            public int age
            {
                get
                {
                    return _age;
                }
                set
                {
                    _age = value;
                    this.OnPropertyChanged();
                }
            }
            private int _height;
            public int height
            {
                get
                {
                    return _height;
                }
                set
                { 
                    _height = value;
                    this.OnPropertyChanged();
                }
            }
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Add Items
            PersonsList.Add(new Person());
        }
    }
