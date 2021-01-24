    public class Drone
    {
        public int ID { get; set; }
        public Point Position { get; set; }
        public bool IsInsideSafearea(Point point)
        {
            throw new NotImplementedException();
        }
    }
    public class Class1
    {
        public void DoSomething()
        {
            var drones = new Drone[]
            {
                new Drone() {ID = 0, Position = new Point(1, 2) },
                new Drone() {ID = 1, Position = new Point(3, 4) },
                new Drone() {ID = 2, Position = new Point(4, 2) },
            };
            var myDrone = drones[0];
            bool result = drones
                .Where(d => d.ID != myDrone.ID)
                .All(d => d.IsInsideSafearea(myDrone.Position));
        }
    }
