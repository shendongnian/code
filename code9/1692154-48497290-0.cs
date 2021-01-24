    class GoodGroup
    {
        public int Id {get; set;}  // no need for attribute, automatically primary key
        // a GoodGroup has zero or more Goods:
        public virtual ICollection<Good> Goods {get; set;}
        ... // other properties
    }
    class Good
    {
         public int Id {get; set;}
         // every good belongs to exactly one GoodGroup using foreign key
         public int GoodGroupId {get; set;}
         public virtual GoodGroup GoudGroup {get; set;}
         ... // other properties
    }
