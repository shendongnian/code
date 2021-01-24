        public class Team
        {
            public string Id { get; set; }
            public List<Driver> Drivers { get; set; }
        }
        public class Driver
        {
            public string DriverId { get; set; }
            public bool IsMainDriver { get; set; }
        }
        public List<string[]> GetDriverMovementList(List<Team> originalTeams, List<Team> modifiedTeams)
        {
            var output = new List<string[]>();
            foreach (var team in modifiedTeams)
            {
                foreach (var driver in team.Drivers)
                {
                    // check this team
                    var driverOrig = originalTeams.Where(x => x.Id == team.Id).SelectMany(x => x.Drivers).Where(x => x.IsMainDriver != driver.IsMainDriver).FirstOrDefault();
                    if (driverOrig == null)
                    {
                        // check other teams
                        driverOrig = originalTeams.Where(x => x.Id != team.Id).SelectMany(x => x.Drivers).Where(y => y.DriverId == driver.DriverId).FirstOrDefault();
                    }
                    if (driverOrig != null)
                    {
                        var oldTeam = originalTeams.Where(x => x.Drivers.Contains(driverOrig)).FirstOrDefault();
                        output.Add(new string[] { team.Id, GetDriverRoleName(driver.IsMainDriver) });
                        output.Add(new string[] { oldTeam.Id, GetDriverRoleName(driverOrig.IsMainDriver) });
                    }
                }
            }
            return output;
        }
        public static string GetDriverRoleName(bool isMainDriver)
        {
            if (isMainDriver) { return "Driver"; } else { return "Codriver"; }
        }
