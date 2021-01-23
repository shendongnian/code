        namespace CrossTest_V2.Models
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        
        public partial class C400_Article_Search_Tree_Allocation
        {
            public string ArtNr { get; set; }
            public Nullable<int> DLNr { get; set; }
            public Nullable<int> SA { get; set; }
            public string Reserviert { get; set; }
            public Nullable<int> GenArtNr { get; set; }
            public string LKZ { get; set; }
            public Nullable<int> LfdNr { get; set; }
            public Nullable<int> SortNr { get; set; }
            public Nullable<int> KritNr { get; set; }
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string KritWert { get; set; }
            public Nullable<int> Exclude { get; set; }
            public Nullable<int> AnzSofort { get; set; }
            public int pk { get; set; }
    
            public virtual ICollection<Ktype> Ktype { get; set; }
        }
    }
