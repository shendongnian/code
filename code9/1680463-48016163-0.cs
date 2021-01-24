    public class ItemData
    {
        public string Name { get; set; }
        public uint ID { get; set; }
        public virtual Item GetItem()
        {
            return new Item(this);
        }
    }
    public class BallData : ItemData
    {
        public float Radius { get; set; }
        public override Item GetItem()
        {
            return new Ball(this);
        }
    }
