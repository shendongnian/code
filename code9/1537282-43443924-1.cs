    public class Entity 
    {
        public long Id { get; set; }
        public string Field { get; set; }
    }
    
    var entities = new Entity[] 
    {
        new Entity() { Field = "A" },
        new Entity() { Field = "B" },
    };
    _dbContext.Entities.AddRange(entities);
