    [Serializable]
    public class DataGridViewColumnProxy
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        int _index;
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public DataGridViewColumnProxy(DataGridViewColumn column)
        {
            this._name = column.DataPropertyName;
            this._index = column.DisplayIndex;
        }
        public DataGridViewColumnProxy()
        {
        }
    }
    [Serializable]
    public class DataGridViewColumnCollectionProxy
    {
        List<DataGridViewColumnProxy> _columns = new List<DataGridViewColumnProxy>();
        public List<DataGridViewColumnProxy> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        public DataGridViewColumnCollectionProxy(DataGridViewColumnCollection columnCollection)
        {
            foreach (var col in columnCollection)
            {
                if (col is DataGridViewColumn)
                    _columns.Add(new DataGridViewColumnProxy((DataGridViewColumn)col));
            }
        }
        public DataGridViewColumnCollectionProxy()
        {
        }
        public void SetColumnOrder(DataGridViewColumnCollection columnCollection)
        {
            foreach (var col in columnCollection)
                if (col is DataGridViewColumn)
                {
                    DataGridViewColumn column = (DataGridViewColumn)col;
                    DataGridViewColumnProxy proxy = this._columns.FirstOrDefault(p => p.Name == column.DataPropertyName);
                    if (proxy != null)
                        column.DisplayIndex = proxy.Index;
                }
        }
    }
