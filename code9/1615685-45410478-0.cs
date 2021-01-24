       private ObservableCollection<string> _pickerItems = new ObservableCollection<string>();
    
            public YourViewModel()
            {
                PickerItems.Add("item1");
                PickerItems.Add("item2");
                PickerItems.Add("item3");
            }
    
    
            public ObservableCollection<string> PickerItems
            {
                get { return _pickerItems; }
                set
                {
                    _pickerItems = value;
                    OnPopertyChanged("PickerItems");
                }
            } 
