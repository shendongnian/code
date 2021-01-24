    public class EntityField
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
    
    public class SyncEntity
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Modified { get; set; }
        public List<EntityField> EntityFields { get; set; }
    }
