    public class UserInstitutionAssociation {
        public Guid ID { get; set; }
    
        [Required]
        [ForeignKey("User")]
        public string UserID {get; set; }
        public virtual User User { get; set; }
        [Required]
        [ForeignKey("Institution")]
        public Guid InstitutionID { get; set; }
        public virtual Institution Institution {get; set;}
    }
