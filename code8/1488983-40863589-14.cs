    private object getProperty(EToolsViewer.APIModels.InstanceDataLog e, string propName)
        {
     var propInfo =typeof(EToolsViewer.APIModels.InstanceDataLog).GetProperty(propName);
    	return propInfo.GetValue(e);		
    }
