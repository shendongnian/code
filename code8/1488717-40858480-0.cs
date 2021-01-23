    public class MenuItem
    {
        public MenuItem( string displayText, Type targetPage )
        {
            DisplayText = displayText;
            TargetPage = targetPage;
        }
    
        public string DisplayText { get; }
    
        public Type TargetPage { get; }
    }
