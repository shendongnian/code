    using (var dsAlertsPointData = new DataSet())
    {
    	dsMergedAlertsPointData = new DataSet();
    	dsMergedAlertsPointData.Tables.Add("AlertsPointData");
    
    	dtAlertsData = processedAlertsData.ToDataTable();
    
    	foreach (var singleAlert in processedAlertsData)
    	{
    		if (singleAlert.AlertsPointsData.Count > 0)
    			dsAlertsPointData.Tables.Add(singleAlert.AlertsPointsData.ToDataTable());
    	}
    
    	for (var i = 0; i < dsAlertsPointData.Tables.Count; i++)
    	{
    		dsMergedAlertsPointData.Tables["AlertsPointData"].Merge(dsAlertsPointData.Tables[i]);
    	}
    }
