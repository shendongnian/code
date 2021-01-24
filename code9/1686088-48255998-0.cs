    public partial class Default : System.Web.UI.Page
        {
            public String Name = "X";
            protected void Page_Load(object sender, EventArgs e)
            {
               
            }
           
            protected String Getname()
            {
                return Name.ToString();
            }
        }
