    static async void CrmInternalFunctionThatKicksOffPlugins()
    {
    	var plugin = new YourPlugin();
    	//NOTE Crm is not going to "await" your plugin execute method here
    	plugin.Execute();
    	"CRM is Done".Dump();
    }
    
    public class YourPlugin
    {
    	public async void Execute()
    	{
    		await OnlineSignUp();	
    	}
    
    	private async Task<HttpResponseMessage> OnlineSignUp()
    	{
    		var httpClient = new HttpClient();
    		var r = await httpClient.PostAsync("http://www.example.com", null);
    		"My Async Finished".Dump();
    		return r;
    	}
    }
