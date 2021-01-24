    namespace DL.SO.StudentQualification.Data
    {
        using System;
        using System.Collections.Generic;
    
        public partial class Qualification
        {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public string QualificationName { get; set; }
            public string Institute { get; set; }
            public Nullable<System.DateTime> EffectiveDate { get; set; }
    
            public virtual Student Student { get; set; }
        }
    }
