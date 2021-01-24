    class Person
    {
        public int Id {get; set;}
        // every person has zero or more items:
        public virtual ICollection<Item> Items {get; set;}
        public Gender Gender {get; set;}
        ... // other properties
    }
    class Item
    {
        public int Id {get; set;}
        // every Item belongs to exactly one Person using foreign key
        public int PersodId {get; set;}
        public virtual Person Person {get; set;}
        public string Name {get; set;}
        ... // other properties
    }
