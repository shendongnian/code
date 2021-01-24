    namespace TestEF6.Data
    {
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
    
        [Table("PROJECT")]
        public partial class PROJECT
        {
            public PROJECT()
            {
                ORDERS = new HashSet<ORDER>();
            }
    
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
    
            [StringLength(50)]
            public string NAME { get; set; }
    
            public virtual ICollection<ORDER> ORDERS { get; set; }
        }
    }
