    public class Theme
    {        
        public Theme(bool active)
        {
            Active = active;
        }
        
        public Color FColor { get; set; } = Color.White;
        public Color BColor { get; set; } = Color.Black;
        public bool Active { get; set; }
    }
    // Use. 
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public Theme theme { get; set; }
    public void Test()
    {
        theme = new Theme(true) { BColor = Color.Gray, FColor = Color.Black };
    }
