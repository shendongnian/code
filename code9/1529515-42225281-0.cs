    public class Drone
    {
        public Point Location { get; }
        public int SafeAreaRange { get; } // can be constant
        public bool SafeAreaContains(Point location)
        {
            var dx = Math.Abs(Location.X - location.X);
            var dy = Math.Abs(Location.Y - location.Y);
            var distance = Math.Sqrt(Math.Pow(dy, 2) + Math.Pow(dx, 2));
            return distance < SafeAreaRange;
        }
    }
