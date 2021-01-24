    class Profile
    {
        public int Id {get; set;}
        // a Profile has zero or more followers:
        public virtual ICollection<Follower> Followers {get; set;}
        ...
    }
    class Follower
    {
        public int Id {get; set;}
        
        // a follower belongs to exactly one Profile (via foreign key ProfileId)
        public int ProfileId {get; set;}
        public virtual Profile Profile {get; set;}
        ...
    }
