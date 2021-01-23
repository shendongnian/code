    public class DataUnitModel
    {
        public object Element { get; set; }
    
        public string ElementText { get { return Element as string; } }
    
        public Image ElementImage { get { return Element as Image; } }
    
        public Type ElementType { get { Element != null ? Element.GetType() : null; }
    
        public bool IsElementText { get { return Element is string; } }
    
        public bool IsElementImage { get { return Element is Image; } }
    }
