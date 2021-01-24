    if (startNode != endNode)
    {
        // Create and Initialise pathfinder here
        MyPathFinderObject pathfinder = new MyPathFinderObject(<parameters>);
        List<Geo_Model_Struct> route = pathfinder.getRouteOptimised(startNode, endNode);
        if (route.Count <= 0)
            .../...
        else
        {                        
            // Create and Initialise accessiblePathfinder here
            MyAccessiblePathFinderObject accessiblePathfinder = new MyAccessiblePathFinderObject(<parameters>);
            List<Geo_Model_Struct> accessibleRoute = accessiblePathfinder.getRouteOptimised(startNode, endNode);
            .../...
        }            
    }
