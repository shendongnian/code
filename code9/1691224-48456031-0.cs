    public class Foo
    {
        public int ID { set; get; }
        public string Name { set; get; } 
        [NotMapped]
        public bool IsDeleted { set; get; }
    }
