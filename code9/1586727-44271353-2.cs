    public class Overlay
    {
        public int PinkBoxLeft { get; set; }
        public int PinkBoxBoxTop { get; set; }
        public int PinkBoxHeight { get; set; }
        public int PinkBoxWidth { get; set; }
    }
    
    public class Mask
    {
        public string PinkBoxText { get; set; }
        public Overlay Overlay { get; set; }
    }
    
    
    var mask = new Mask();
    if (isOverlayRequired)
    {
        mask.Overlay = new Overlay();
    }
