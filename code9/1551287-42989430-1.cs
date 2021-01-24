        [Table("UserAccounts")]
        public class UserAccounts
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string UserName { get; set; }
    
            public virtual ICollection<Fleets> Fleets { get; set; }
        }
        [Table("Fleets")]
        public class Fleets
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual UserAccounts UserAccount { get; set; }
        }     
