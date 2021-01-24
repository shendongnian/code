    var waypoints = from team in teams
                    join route in Routes on team.TeamID equals route.TeamID into rList
                    select new {
                        team.teamName,
                        Rlist = (from route in rList
                                 join waypoint in WayPoints on route.RouteID equals waypoint.RouteRouteID into wList
                                 select new {
                                     route,
                                     Wlist = wList.ToList()
                                 }).ToList()
};
