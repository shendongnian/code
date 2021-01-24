    void Start()
    {
        unsafe
        {
            fixed (TrafficRoadSystem** addressOfTrafficRoadSystem = &trafficRoadSystem)
            {
                string osmPath = "Assets/Resources/map.osm.pbf";
                int results;
                results = traffic_import_osm(osmPath, addressOfTrafficRoadSystem);
            }
        }
    }
