            public class Customer
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string ZipCode { get; set; }
            }
            public class User
            {
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                public int Id { get; set; }
                [Column("Name")]
                public string Name { get; set; }
       
            }
