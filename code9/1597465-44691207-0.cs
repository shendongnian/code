    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
    
        [Required]
        public int CreatedBy_Id { get; set; }
        [ForeignKey("CreatedBy_Id")]
        public virtual User CreatedBy { get; set; }
    
        public int? UpdatedBy_Id { get; set; }
        [ForeignKey("UpdatedBy_Id")]
        public virtual User UpdatedBy { get; set; } 
    
        //add these properties
        [InverseProperty("CreatedBy")]
        public virtual ICollection<User> WereCreated {get; set;}
        [InverseProperty("UpdatedBy")]
        public virtual ICollection<User> WereUpdated {get; set;}
    }
