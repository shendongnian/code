    // Parent
    public partial class Parent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var doesStuff = DoesStuff1 as DoesStuff;
            if (doesStuff != null) DoesStuff1.DisplayMessage("Hello from Parent!");
        }
    }
    
    // Child
    public partial class DoesStuff : System.Web.UI.UserControl
    {
        public void DisplayMessage(string message)
        {
            ChildLabel.Text = message;
        }
    }
