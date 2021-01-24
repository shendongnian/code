    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Button button1=null;
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            button1 = new Button();
            button1.ID="Button1";
            button1.OnClick += Button1_Click;
            this.Controls.Add(button1);   
        }
    
    }
