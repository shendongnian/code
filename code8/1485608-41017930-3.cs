    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    
    namespace Postal.Models
    {
        public class Reciept
        {
            [Key]
            [Required]
            [Display(Name = "Book No. : ")]
            public virtual string Book_no { get; set; }
            
            [Required]
            [Display(Name = "PO code : ")]
            //public virtual string po_code { get; set; }
    
            public virtual Post_Office po { get; set; }
            
            [Display(Name = "Add Date : ")]
            public virtual DateTime? Add_date { get; set; }
    
            [Display(Name = "Add User. : ")]
            public virtual string Add_user { get; set; }
    
            [Display(Name = "IP Address : ")]
            public virtual string Add_ip_address { get; set; }
        }
    }
