    public class ThemeProperty
    {        
        public Color FColor { get; set; } = Color.White;
        public Color BColor { get; set; } = Color.Black;
        public bool Active { get; set; } = true;
    }
    // Use.
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public ThemeProperty Theme { get; set; } = new ThemeProperty();
 
    public void Test()
    {
         Theme.BColor = Color.Gray;
         Theme.FColor = Color.Black;
         Theme.Active = true;
    }
