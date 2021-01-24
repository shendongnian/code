    public class ThemeProperty
    {
        public Color FColor { get; set; }
        public Color BColor { get; set; }
        public bool ActivePassive { get; set; }
        public void ThemeProperty(bool state)
        {
            ActivePassive = state;
            FColor = Color.White;
            BColor = Color.Black;
        }
    }
