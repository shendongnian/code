    public class TwitterUser {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [ManyToMany(typeof(FollowerLeaderRelationshipTable), "LeaderId", "Followers",
            CascadeOperations = CascadeOperation.All)]
        public List<TwitterUser> FollowingUsers { get; set; }
        // ReadOnly is required because we're not specifying the followers manually, but want to obtain them from database
        [ManyToMany(typeof(FollowerLeaderRelationshipTable), "FollowerId", "FollowingUsers",
            CascadeOperations = CascadeOperation.CascadeRead, ReadOnly = true)]
        public List<TwitterUser> Followers { get; set; }
    }
    // Intermediate class, not used directly anywhere in the code, only in ManyToMany attributes and table creation
    public class FollowerLeaderRelationshipTable {
        public int LeaderId { get; set; }
        public int FollowerId { get; set; }
    }
