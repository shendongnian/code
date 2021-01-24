     [Table("your View table name", Schema = "your schema name")]
        public class vTest
        {
            [Key]
            public int TestAutoId{ get; set; }
            public string TestName{ get; set; }
            public string TestDescription { get; set; }
        }
