    public class MainWindowViewModel : ViewModelsBase
    {
        public MainWindowViewModel()
        {
            _fields = CreateFieldsCollection();
            _fields.CollectionChanged += _fields_CollectionChanged;
        }
        private ObservableCollection<Field> CreateFieldsCollection()
        {
            ObservableCollection<Field> fieldsCollection = new ObservableCollection<Field>();
            fieldsCollection.Add(new Field() { Begin = 0, Length = 5 });
            fieldsCollection.Add(new Field() { Begin = 5, Length = 5 });
            fieldsCollection.Add(new Field() { Begin = 10, Length = 5 });
            fieldsCollection.Add(new Field() { Begin = 15, Length = 5 });
            fieldsCollection.Add(new Field() { Begin = 20, Length = 5 });
            foreach (Field field in fieldsCollection)
                field.PropertyChanged += item_PropertyChanged;
            return fieldsCollection;
        }
        private void _fields_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object field in e.NewItems)
                {
                    (field as INotifyPropertyChanged).PropertyChanged
                        += new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (object country in e.OldItems)
                {
                    (country as INotifyPropertyChanged).PropertyChanged
                        -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
        }
        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_fields.Count < 2)
                return;
            switch(e.PropertyName)
            {
                case "Length":
                    //recalculate the begin of each field
                    RecalculateBegin();
                    break;
                case "Begin":
                    Field modifiedField = sender as Field;
                    int indexOfModifiedField = FieldsCollection.IndexOf(modifiedField);
                    if(indexOfModifiedField > 0)
                    {
                        //recalculate the length of the previous field:
                        Field previousField = FieldsCollection[indexOfModifiedField - 1];
                        previousField.Length = modifiedField.Begin - previousField.Begin;
                    }
                    //...and the recalculate the begin of the rest of the fields:
                    RecalculateBegin();
                    break;
            }
        }
        private void RecalculateBegin()
        {
            int length = _fields[0].Begin + _fields[0].Length;
            for (int i = 1; i < FieldsCollection.Count; ++i)
            {
                FieldsCollection[i].Begin = length;
                length += FieldsCollection[i].Length;
            }
        }
        private ObservableCollection<Field> _fields;
        public ObservableCollection<Field> FieldsCollection
        {
            get { return _fields; }
            set
            {
                if (_fields != value)
                {
                    _fields = value;
                    RaisePropertyChanged("FieldsCollection");
                }
            }
        }
    }
