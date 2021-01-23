    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DynamicEFLoading
    {
        public abstract class Person
        {
            [Key]
            public int PersonId { get; set; }
            public int PersonAge { get; set; }
            public int PersonWeight { get; set; }
            public string PersonName { get; set; }
        }
        class Child : Person
        {
            [Key]
            [Column(Order = 0)]
            public int Id { get; set; }
            public string sChildFoo { get; set; }
            public int iChildBar { get; set; }
            public double dChildBaz { get; set; }
        }
    }
