    public partial class YourPage : System.Web.UI.Page
    {
        public string strApplication1 {get; set;}
        protected void Page_Load(object sender, EventArgs e)
        {
             //Your page logic          
        }
        //Looks like you set the variable in an onDatabound or similar.
        //So use this where you currently set the variable
        strApplication1 = Details.CommandArgument.ToString();
              
    }
