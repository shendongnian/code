    namespace CrossTest_V2.Models
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        
        public partial class Ktype
        {
            [ForeignKey("KritWert")]
            public int KritWert { get; set; }
            public Nullable<int> Amount { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Type_Description { get; set; }
    
            public virtual C400_Article_Search_Tree_Allocation C400Ktype { get; set; }
        }
    }
