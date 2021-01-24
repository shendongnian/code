    public class BrandColors :CSSItem
    {   
        public Color color { get; set; }    
        public string HexCode
        {
            get { return color.Name.PadLeft(6, '0'); }
        }
        // something similar for RGBCode, however you calculate that
    }
