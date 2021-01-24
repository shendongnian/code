    public partial class DynamicGridView : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!IsPostBack)
    		{
    			var test = new ButtonField();
    			test.Text = "Details";
    			test.ButtonType = ButtonType.Button;
    			test.CommandName = "test";
    			GridView1.Columns.Add(test);
    
    
    			GridView1.DataSource = new[] {
    				new {Id= 1, Text = "Text 1"  },
    				new {Id= 2, Text = "Text 2"  },
    			};
    			GridView1.DataBind();
    		}
    	}
    
    	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    	{
    		if (e.CommandName == "test")
    		{
    			ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Event works')", true);
    		}
    	}
    }
