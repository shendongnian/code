    [HubMethodName("sendNotifications")]
    public Task<object> SendNotifications()
    {
    	DataTable dt = new DataTable();
    	using (var connection = new SqlConnection(strConnectionString))
    	{
    		connection.Open();
    		using (SqlCommand command = new SqlCommand(query, connection))
    		{
    			command.Notification = null;
    			if (ServiceController.dependency == null)
    			{
    				ServiceController.dependency = new SqlDependency(command);
    				ServiceController.dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
    			}
    			var reader = command.ExecuteReader();
    			dt.Load(reader);
    			connection.Close();
    		}
    	}
    	IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BroadcastHub>();
    	var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
    	return (context.Clients.All.RecieveNotification(json));
    }
    private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
    	if (e.Type == SqlNotificationType.Change)
    	{
    		if (ServiceController.dependency != null)
    		{
    			ServiceController.dependency.OnChange -= dependency_OnChange;
    			ServiceController.dependency = null;
    		}
    		SendNotifications();
    	}
    }
