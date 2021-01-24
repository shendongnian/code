    class Item
    {
        public const string Hub = "HUB";
        public string LevelFirst { get; set; }
        public string LevelSecond { get; set; }
        public bool HasCommonLevelWith(Item other)
        {
            if (other == null || ContainsAHub() || other.ContainsAHub())
            {
                return false;
            }
            return
                LevelFirst.Equals(other.LevelFirst, StringComparison.OrdinalIgnoreCase) ||
                LevelSecond.Equals(other.LevelSecond, StringComparison.OrdinalIgnoreCase);
        }
        public bool ContainsAHub()
        {
            return LevelFirst.Equals(Hub, StringComparison.OrdinalIgnoreCase) ||
                   LevelSecond.Equals(Hub, StringComparison.OrdinalIgnoreCase);
        }
    }
