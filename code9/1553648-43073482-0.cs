    public Foo MySelectedItem
    {
        get { return _mySelectedItem; }
        set
        {
            if (Equals(value, _mySelectedItem)) return;
            _mySelectedItem = value;
            NotifyOfPropertyChange();
            int temp = MySelectedIndex;
            MyArray = new[] { "othervalue1", "othervalue2", "othervalue3" };
            NotifyOfPropertychange(() => MyArray);
            SelectedIndex = temp;
            NotifyOfPropertychange(() => SelectedIndex);
        }
    }
