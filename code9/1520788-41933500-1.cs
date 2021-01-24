    public partial class Default : System.Web.UI.Page
         {
            DataAccess objDaAccess = new DataAccess();
            protected void Page_Load(object sender, EventArgs e)
            {
        
            }
        
            protected void submitEventMethod2(object sender, EventArgs e)
            {
                this.Mymethod();
            }
            public void Mymethod()
            {
               TextBox1.Text = "some text";
               objDaAccess.value=TextBox1.Text;
            }
        class Myclass
        {
           TextBox1.Text = objDaAccess.value;
        }
    }
