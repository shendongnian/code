        public class CustomMap : Map
        {
            public List<List<Position>> ShapeCoordinates { get; set; }
    
            public CustomMap()
            {
                ShapeCoordinates = new List<List<Position>>();
            }
        }
