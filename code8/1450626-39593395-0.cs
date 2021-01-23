            Item _SelectedItem;
            public Item SelectedItem
            {
                get
                {
                    return _SelectedItem;
                }
                set
                {
                    if (_SelectedItem!= value)
                    {
                        _SelectedItem= value;
                        RaisePropertyChanged("SelectedItem");
                    }
                }
            }
