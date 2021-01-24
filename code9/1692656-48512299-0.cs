    public class DisplayPanel
    {
        public Panel Panel { get; set; }
        public ComboBox Sort { get; set; }
        public ComboBox Dir { get; set; }
        ...
        public DisplayPanel(Panel panel, ComboBox Sort, ComboBox Dir ...)
        {
            ...
        }
        public bool Validated()
        {
            // what ever your validate critria is here i.e
            // what makes this panel complete to show the next panel
        }
        public bool Activate()
        {
            ...
        }
        public bool Deactive()
        {
            ...
        }
    }
