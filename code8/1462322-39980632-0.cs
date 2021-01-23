    private List<sting> _Items;
    private List<string> _Uprices;
    
    StringBuilder myItems = StringBuilder();
    foreach (var i = 0; i < _Items.Count; i++) {
        myItems.AppendLine(_Items[i].PadRight(30) + _Uprices[i]);
    }
    
    Console.Write(myItems);
