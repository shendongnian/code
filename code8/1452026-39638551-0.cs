    public class User
    {
        public User()
       {
       }
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int UserID { get; set; }
       public Guid UserGuid { get; set; }
       public string Email { get; set; }
       public string Name { get; set; }
       public int CompanyID { get; set; }
       public virtual Status Status { get; set; }
       public virtual UserRole UserRole { get; set; }
       }
    }
