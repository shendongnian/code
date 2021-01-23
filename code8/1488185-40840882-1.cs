    public class PanelEventArg : EventArgs
    {
        public PanelBase Panel { get; set; }
    }
    public class PanelBase //: Panel
    {
        public EventHandler OnSomeEvent = new EventHandler((sender, e) => { }); //stub;
        
        public void OnSetPanel(object sender, PanelEventArg e)
        {
            if (!Equals(e.Panel, this))
            {
                //the panel being set is not this panel instance
            }
        }
    }
