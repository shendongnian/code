        [Table("UserAccounts")]
        public class UserAccounts
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string UserName { get; set; }
    
            public virtual Fleets Fleet { get; set; }
        }
        [Table("Fleets")]
        public class Fleets
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Name { get; set; }
        }     
