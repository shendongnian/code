    public ObservableCollection<Item> MyItems {
            get {
                var _items = new ObservableCollection<Item>();
                _items.Add(new Item { Key = "Key1", Value = "Value1" });
                _items.Add(new Item { Key = "Key2", Value = "Value2" });
                _items.Add(new Item { Key = "Key3", Value = "Value3" });
                return _items;
            }
        }
