    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    
    namespace Postal.Models
    {
        public class Post_Office
        {
            [Key]
            [Required]
            [Display(Name = "PO code : ")]
            public virtual string PO_CODE { get; set; }
    
            [Required]
            [Display(Name = "PO Name : ")]
            public virtual string PO_NAME { get; set; }
    
            [Display(Name = "PO_TYPE : ")]
            public virtual string PO_TYPE { get; set; }
    
            [Display(Name = "PO_ADD1 : ")]
            public virtual string PO_ADD1 { get; set; }
    
        }
    }
