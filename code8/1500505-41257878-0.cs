    public class DataUnitModel
    {
        public object Element { get; set; }
    
        public string ElementText { get { return Element as string; } }
    
        public Image ElementImage { get { return Element as Image; } }
    
        public Type ElementType { get; set; }
    }
