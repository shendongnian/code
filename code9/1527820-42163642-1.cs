        //Business layer
    public class Product
    {
    	public string ProductName {get;set;}
    	public int Quantity {get;set;}
    	public string Unit {get;set;}
    	public decimal Price {get;set;}
    	public long Total {get;set;}
    	
    	public Product(){}
    	
    	public Product(string productName, int quantity, string unit, decimal price, long total)
    	{
    		ProductName = productName;
    		Quantity = quantity;
    		Unit = unit;
    		Price = price;
    		Total = total;
    	}
    	
    	public List<Product> GetProductList()
    	{
    		//get the list of products from the data access layer
    		ProductDal dal = new ProductDal();
    		return dal.GetProductList();
    	}
    }
    
    //Data layer
    public class ProductDal
    {
    	public List<Product> GetProductList()
    	{
    		List<Product> lstProducts = new List<Product>();
    		//connect to your database code here
    		
    		//fill your list with records from your Sql query
    		//inside your DataReader while loop you can add a new Product object to your list for each record
    		//assuming your database field names match the Product class's proeprties you would do this
    		lstProducts.Add(new Product((string)reader["ProductName"],
    									(int)reader["Quantity"],
    									(string)reader["Unit"], 
    									decimal)reader["Price"],
    									(long)reader["Total"]));
    		
    		return lstProducts;
    	}
    }
    
    //front end code behind page
    private void button2_Click(object sender, EventArgs e)
        {
    		Product product = new Product();
    		dgvCart.DataScource = product.GetProductList();
    		dgvCart.DataBind();
        }
