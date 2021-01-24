    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Linq.Mapping;
    
    namespace MvcApplication1.Models
    {
        [Table(Name = "student")]
        public class student
        {
            [Column(IsPrimaryKey = true)]
            public int stu_id { get; set; }
            [Column]
            public string stu_name { get; set; }
            [Column]
            public int stu_age { get; set; }
            [Column]
            public string course { get; set; }
            [Column]
            public int fees { get; set; }
    
        }
    }
