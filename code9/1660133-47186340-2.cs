    private void OnEnable()
    {
    	TransporterSystem system = FindObjectOfType<TransporterSystem>();
    	if (system == null)
    	{
    		Debug.LogError("No TransporterSystem in scene.");
    	}
    	else
    	{
    		nodes = system.GetAllTransporterNodes();
    	}
    }
