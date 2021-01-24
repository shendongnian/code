    protected void ReArrangeRouteOrderForAreas()
        {
            try
            {
                RouteBase[] areaRoutes = new RouteBase[4];
                string[] areaRouteNames = new string[] { "area_1", "area_2", "area_3", "area_4" };
                for (int i = 3; i >= 0; i--)
                {
                    //Remove the reversed area routes and assign them into an array.
                    areaRoutes[i] = RouteTable.Routes[12];
                    RouteTable.Routes.RemoveAt(12);
                }
                for (int i = 0; i < 4; i++)
                {
                    //Add with the order in area_1/area_2/area_3/area_4
                    RouteTable.Routes.Add(areaRouteNames[i], areaRoutes[i]);
                }
            }
            catch(Exception ex)
            {
            }
            
        }
