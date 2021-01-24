    namespace GridViewWithAjaxIIIWebApplication.Controllers
    {   
        public class ProductsWebAPIEmptyController : ApiController
        {
            [HttpGet, HttpPost ]
            public static string GetCustomers()
            {
                string query = "Select Product_Id, Product_Name, Product_Description, Product_Category, Product_Price, Product_Quantity from Items";
    
    
                String cs = ConfigurationManager.ConnectionStrings["WebShopDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        SqlCommand cmd = new SqlCommand();
                        sda.SelectCommand = cmd;
                        cmd.Connection = con;
                        cmd.CommandText = query;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            return ds.GetXml();
                        }
                    }
                }
            }
        }
    }
