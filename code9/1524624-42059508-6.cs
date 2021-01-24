    public partial class DoesStuff : System.Web.UI.UserControl
    {
        public event EventHandler ChildButtonClicked = delegate { };
            
        protected void BubbleUpButton_OnClick(object sender, EventArgs e)
        {
            // bubble up the event to parent. 
            ChildButtonClicked(this, new EventArgs());
        }
    }
