    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init()
        {
            CreateButton();
        }
    
        protected void myButton_Click(object sender, EventArgs e)
        {
        }
    
        private void CreateButton()
        {
            Button myButton = new Button();
            myButton.ID = "b1";
            myButton.Text = "Buy Now!";
            myButton.CssClass = "btn-primary";
            myButton.Click += new EventHandler(myButton_Click);
            myPlaceHolder.Controls.Add(myButton);
        }
    }
