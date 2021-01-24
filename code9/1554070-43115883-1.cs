    public class MyTableClass
    {
        public int Id { get; set; }
    
        [Column(TypeName = "jsonb")]
        public string Data { get; set; }
    }
