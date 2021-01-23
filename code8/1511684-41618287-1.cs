    public class HomeShowModel 
    {
        public string SelectedHomeShow { get; set; }
        // Other properties you may need
        // Name this property something meaningful
        public bool NeedsPartial 
        { 
            return this.SelectedHomeShow == "StockParts";
        }
    }
