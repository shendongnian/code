    class Member
    {
        public int Id {get; set;}
        ...
        // Navigation properties:
        // a member belongs to exactly one ReferenceClass via foreign key
        public int ReferenceClassId {get; set;}
        public ReferenceClass ReferenceClass {get; set;}
    }
    class ReferenceClass {get; set;}
    {
        public int Id {get; set;}
        ...
        // Navigation Properties:
        // A reference class has zero or more Members:
        public virtual ICollection<Member> Members {get; set;}
    }
