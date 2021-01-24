    public class Parent
    {
       // The parent/child relationship is implicit, even though the tables
       // themselves indicate a many-to-many relationship
       public static List<Parent> Parents { get; set; }
       
       // Unique primary key
       public int PrimaryKey { get; set; }
       // These two fields together compose the foreign key to join to Child
       public string ParentForeignKey1 { get; set; }
       public string ParentForeignKey2 { get; set; }
       public List<Child> Children { get; set; }
    }
    public class Child
    {
       // Unique primary key
       public int PrimaryKey { get; set; }
       // These two fields together compose the (non-unique) foreign key to join to Parent
       public string ChildForeignKey1 { get; set; }
       public string ChildForeignKey2 { get; set; }
    }
