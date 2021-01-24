    public class ScrollableControlBasedControl : ScrollableControl
    {
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new ReadOnlyControlCollection(this);
        }
        
        // The rest of your class goes here...
    }
