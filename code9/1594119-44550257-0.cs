    namespace Vidly.Models
    {
        public class Customer
        {
            public int Id { get; set; }
    
            [Required]
            [StringLength(255)]
            public string Name { get; set; }
    
            public bool IsSubscribedToNewsletter { get; set; }
    
           
    
            [Display(Name = "Membership Type")]
            public byte MembershipTypeId { get; set; }
    
            [Display(Name = "Date of Birth")]
            public DateTime? Birthdate { get; set; }
    
    
         public virtual  MembershipType MemshipType { get; set; }
        }
    
        
        public class MembershipType
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public short SignupFee { get; set; }
            public byte DurationInMonths { get; set; }
            public byte DiscountRate { get; set; }
    
           public virtual  Customer  customer{ get; set; }
        }
      			
    }
