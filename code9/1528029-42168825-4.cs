    namespace TestEF6.Data
    {
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
    
        [Table("ORDER")]
        public partial class ORDER
        {
            public ORDER()
            {
                PROJECTS = new HashSet<PROJECT>();
            }
    
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
    
            [StringLength(50)]
            public string NAME { get; set; }
    
            public virtual ICollection<PROJECT> PROJECTS { get; set; }
        }
    }
