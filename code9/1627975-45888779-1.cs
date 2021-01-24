    public class SampleViewModel
    {
        public Dictionary<string, string> Items { get; set; }
    
        public string SelectedItem { get; set; }
    
        public SampleViewModel()
        {
            Items = new Dictionary<string, string>();
        }
    }
