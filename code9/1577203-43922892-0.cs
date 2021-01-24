    public class PopupRootAutomationPeer : UIElementAutomationPeer
    {
        public PopupRootAutomationPeer(FrameworkElement owner)
            : base(owner) { }
        protected override string GetClassNameCore()
        {
            return "Pane";
        }
        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Pane;
        }
        protected override string GetNameCore()
        {
            return "PopupRootAutomationPeer";
        }
    }
    // Wrap content of the window with this class
    class PopupRoot : Canvas
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new PopupRootAutomationPeer(this);
        }
    }
