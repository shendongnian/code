    interface IDocument 
    {
        List<IItem> Items { get; }
    }
    
    interface IItem
    {
        // common properties which apply to all items
        // (if they don't apply to all items, they
        // shouldn't be here)
        
        bool CanBreakAcrossPages { get; }
    }
    
    interface ITextualItem : IItem
    {
        string TextFont { get; }
        float TextSize { get; }
        ...
    }
    
    class ParagraphItem : ITextualItem
    {
        public bool CanBreakAcrossPages { get; set; }
        public string TextFont { get; set; }
        public float TextSize { get; set; }
        string Text { get; set; }
    }
    
    ... you get the idea
