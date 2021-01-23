    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations; //Add
    namespace MyNamespace
    {
        public partial class _Food //Prefix with underscore
        {
             [Key] //Add
             public int FoodId { get; set; }
             public string Name { get; set; }
             public string Description { get; set; }
             public double Price { get; set; }
        }
    }
