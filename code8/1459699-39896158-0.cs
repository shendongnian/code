    public class Stuff{
        public int ID { get; set; }
        public string Name { get; set; }
        //your new column
        [Column("my_new_column")]
        public string NewColumn { get; set; }
    }
