    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    
    namespace Treat_Data.Model
    {
        public class Restaurant
        {
            [Key]
            public int Restaurant_ID { get; set; }//this is the primary key
            public string Name { get; set; }
            public string Address { get; set; }
            public string Open_Hours { get; set; }
    
        }
    }
