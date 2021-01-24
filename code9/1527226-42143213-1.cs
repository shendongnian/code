    public partial class ListViewExample : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		var data = new List<ListModel>
    		{
    			new ListModel { ItemName = "Phone", OrderDate = new DateTime(2017-1-12) },
    			new ListModel { ItemName = "Book", OrderDate = new DateTime(2017-1-1) },
    			new ListModel { ItemName = "Desk", OrderDate = new DateTime(2017-3-12) }
    		};
    
    		data.ForEach(x => x.DeliveryDate = CalculateDeliveryDate(x.OrderDate));
    
    		ListView1.DataSource = data.OrderBy(x => x.DeliveryDate);
    		ListView1.DataBind();
    	}
    
    	private DateTime CalculateDeliveryDate(DateTime orderDate)
    	{
    		return orderDate.AddDays(7);
    	}
    }
    
    public class ListModel
    {
    	public string ItemName { get; set; }
    	public DateTime OrderDate { get; set; }
    	public DateTime DeliveryDate { get; set; }
    }
