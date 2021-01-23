    public sealed class Foo
    {
        private readonly ObservableCollection<ObservableCollection<string>> _itemData;
        private readonly ObservableCollection<ReadOnlyObservableCollection<string>> _rowData;
        public Foo()
        {
            _itemData = new ObservableCollection<ObservableCollection<string>>();
            // Fill the _itemData variable
            for (var i = 0; i<10; i++)
            {
                var t = new ObservableCollection<string>();
                for (var j = 0; j<10; j++)
                {
                    t.Add(i + "+" + j);
                }
                _itemData .Add(t);
            }
            _rowData = new ObservableCollection<ReadOnlyObservableCollection<string>>();
            foreach (var row in _itemData )
            {
                _rowData.Add(new ReadOnlyObservableCollection<string>(row));
            }
            Data = new ReadOnlyObservableCollection<ReadOnlyObservableCollection<string>>(_rowData);
        }
        public ReadOnlyObservableCollection<ReadOnlyObservableCollection<string>> Data { get; }
        public void RemoveItem(int x, int y)
        {
            _itemData[x].RemoveAt(y);
        }
        public void RemoveRow(int x)
        {
            _rowData.RemoveAt(x);
        }
    }
