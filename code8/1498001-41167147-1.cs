    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public virtual void Draw(StringBuilder map)
        {
            map.Append("   ");
        }
    }
    class Room : Tile
    { 
        public int EnemyType { get; set; }
        public int Reward { get; set; }
        public override void Draw(StringBuilder map)
        {
            map.Append("[ ]");
        }
    }
    // etc.
