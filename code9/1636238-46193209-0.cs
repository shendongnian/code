    if(query.ClustersSelected.Any())
    {
    	statusViewResult = statusViewResult.Where(p => query.ClustersSelected.Contains(p.Cluster));
    }
    if(query.ParkNamesSelected.Any())
    {
    	statusViewResult = statusViewResult.Where(p => query.ParkNamesSelected.Contains(p.ParkName));
    }
