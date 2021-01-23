    public partial class RepeaterExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var p1 = new Product { ID = 1, ProductName = "Banana" };
                var p2 = new Product { ID = 2, ProductName = "Apple" };
                var p3 = new Product { ID = 3, ProductName = "Orange" };
                Repeater1.DataSource = new List<Product> { p1, p2, p3 };
                Repeater1.DataBind();
            }
        }
        [System.Web.Services.WebMethod]
        public static string ServerCall(int id)
        {
             return "Server response.Processed ID - " + id;
        }
    }
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
    }
