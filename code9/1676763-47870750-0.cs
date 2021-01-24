    public class MyTextBox : System.Web.UI.WebControls.TextBox
    {
        public bool Visible
        {
            get
            {
                return base.Visible;
            }   
            set
            {
                ReallyVisible = value;
                vase.Visible = value;
            }
        }
    
        public bool ReallyVisible { get; private set; }
    }
