    interface IWaypoint
    {
        Point GetPosition();//whatever a waypoint should do
    }
    class Item : IWaypoint
    {
        Point location;
        public Point GetPosition()
        {
           return location;
        }
    }
    class Player : IWaypoint
    {
        Point position;
        float movespeed;
        public Point GetPosition()
        {
            return position * movespeed;
        }
    }
    void main()
    {
        List<IWaypoint> waypoints = new List<IWaypoint>();
        waypoints.Add(new Player());
        waypoints.Add(new Item());
        foreach (IWaypoint wp in waypoints)
        {
            Console.WriteLine(wp.GetPosition());
        }
    }
