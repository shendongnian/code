    public class Room
    {
        private List<Wall> walls;
        public Room(): this(new List<Wall>())
        {
        }
        public Room(List<Wall> walls)
        {
            this.Walls = walls;
        }
        public List<Wall> Walls
        {
            get
            {
                return this.walls;
            }
            set
            {
                foreach (Wall wall in value)
                {
                    if (wall?.Room != this)
                    {
                        throw new ArgumentException("Every wall's room must be this Room instance", nameof(Walls));
                    }
                }
                this.walls = value;
            }
        }
    }
