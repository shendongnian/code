    namespace DL.SO.StudentQualification.Data
    {
        using System;
        using System.Collections.Generic;
    
        public partial class Student
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Student()
            {
                this.Qualifications = new HashSet<Qualification>();
            }
    
            public int Id { get; set; }
            public string Name { get; set; }
            public Nullable<int> Age { get; set; }
            public Nullable<bool> Gender { get; set; }
            public string City { get; set; }
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Qualification> Qualifications { get; set; }
        }
    }
