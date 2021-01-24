    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    
    namespace WebApplication2.Models
    {
        public class Test
        {
            [Required(ErrorMessage="Required")]
            public string str {get; set;}
        }
    }
