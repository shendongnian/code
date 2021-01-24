    private List<Model> _list = new List<Model>();
    void MakeList()
    {
        string[] values = "A~B~C".Split("~".ToCharArray(), StringSplitOptions.None);
        string[] parts = "PartA~PartB~PartC"("~".ToCharArray(), StringSplitOptions.None);
        string[] qtys = "QtyA~QtyB~QtyC"("~".ToCharArray(), StringSplitOptions.None);
        for (int i = 0; i < values.Length; i++)
        {
            var item = new Model(){ Value = values[i], Part = parts[i], Quantity = qtys[i]};
            _list.Add(item);
        }
    }
    string[] GenerateCommaSeparatedRecords()
    {
        return _list.Select(x => string.Format("{0},{1},{2}", x.Value, x.Part, x.Quantity)).ToArray();
    }
    
