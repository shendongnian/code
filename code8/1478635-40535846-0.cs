    public class MyViewModel
    {
        public int MaxOfColumn { get; set; }
        public List<InnerViewModel> Items { get; set; }
    }
    
    public class InnerViewModel
    {
        // Create properties here which represent the Model's columns you need to display
    }
