    public class Entity : SerializableObject<Entity>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Shape Shape { get; set; }
    }
