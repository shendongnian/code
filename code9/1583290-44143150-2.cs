    public partial class _44141788 : System.Web.UI.Page
    {
    	protected Literal uiStyleLink;
    	protected Literal litScript;
    
    	protected override void OnLoad(EventArgs e)
    	{
    		base.OnLoad(e);
    		
    	}
    
    
    	protected void Page_PreRender(object sender, EventArgs e)
    	{
    		ClientScript.RegisterStartupScript(GetType(),  "alert", "alert('hey');", true);
    		
    	}
    }
