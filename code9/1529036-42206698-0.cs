        class Program
        {
            static void Main(string[] args)
            {
                using (var file = File.OpenRead("data.json"))
                {
                    using (var reader = new StreamReader(file))
                    {
                        var content = reader.ReadToEnd();
                        var missions = JsonConvert.DeserializeObject<Mission[]>(content);
                        System.Console.WriteLine(missions);
                    }
                }
            }
        }
    
        public class AirDropPos
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }
    
        public class BoundaryPt
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int order { get; set; }
        }
    
        public class FlyZone
        {
            public double altitude_msl_max { get; set; }
            public double altitude_msl_min { get; set; }
            public List<BoundaryPt> boundary_pts { get; set; }
        }
    
        public class HomePos
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }
    
        public class MissionWaypoint
        {
            public double altitude_msl { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int order { get; set; }
        }
    
        public class OffAxisTargetPos
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }
    
        public class EmergentLastKnownPos
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }
    
        public class SearchGridPoint
        {
            public double altitude_msl { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int order { get; set; }
        }
    
        public class Mission
        {
            public int id { get; set; }
            public bool active { get; set; }
            public AirDropPos air_drop_pos { get; set; }
            public List<FlyZone> fly_zones { get; set; }
            public HomePos home_pos { get; set; }
            public List<MissionWaypoint> mission_waypoints { get; set; }
            public OffAxisTargetPos off_axis_target_pos { get; set; }
            public EmergentLastKnownPos emergent_last_known_pos { get; set; }
            public List<SearchGridPoint> search_grid_points { get; set; }
        }
