    class TableItem : ITextualItem
    {
        // note the recursion here: 
        // ITableItem is an IItem, and it contains a list of IItems,
        // meaning you can even have nested tables inside a single table cell    
    
        public List<IItem> HeaderCols { get; }
        public List<List<IItem>> Rows { get; }
    }
    
