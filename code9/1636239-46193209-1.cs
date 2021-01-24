    if(query.ClustersSelected?.Any() == true)
    {
    	statusViewResult = statusViewResult.Where(p => query.ClustersSelected.Contains(p.Cluster));
    }
    if(query.ParkNamesSelected?.Any() == true)
    {
    	statusViewResult = statusViewResult.Where(p => query.ParkNamesSelected.Contains(p.ParkName));
    }
