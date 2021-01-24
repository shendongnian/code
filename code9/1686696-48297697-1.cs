    public ObservableCollection<Abfahrtskontrolle> Items
                {
                    get { return items; }
                    set
                    {
                        items = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
                    }
                }
