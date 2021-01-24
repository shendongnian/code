    // your custom class
    public partial class MyEntityClass
    {
       public string CustomName => CurrentYear.ToString() + ParentName;
    }
    
    // EF Generated class
    public partial class MyEntityClass
    {
       public int ID { get; set; }
       public int CurrentYear { get; set; }
       public string ParentName { get; set; }
    }
