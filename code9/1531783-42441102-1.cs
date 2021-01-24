    public class Person {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [ManyToMany(typeof(BrothersRelationshipTable), "OldBrotherId", "YoungerBrothers",
            CascadeOperations = CascadeOperation.All)]
        public List<Person> OlderBrothers { get; set; }
        [ManyToMany(typeof(BrothersRelationshipTable), "YoungBrotherId", "OlderBrothers",
            CascadeOperations = CascadeOperation.CascadeRead, ReadOnly = true)]
        public List<Brothers> YoungerBrothers { get; set; }
        [Ignore]
        publc List<TwitterUser> Brothers { 
            get { return YoungerBrothers.Concat(OlderBrothers).ToList() }
        }
    }
    // Intermediate class, not used directly anywhere in the code, only in ManyToMany attributes and table creation
    public class BrothersRelationshipTable {
        public int OldBrotherId { get; set; }
        public int YoungBrotherId { get; set; }
    }
