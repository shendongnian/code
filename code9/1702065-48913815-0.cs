    using System; 
    using System.Collections.Generic; 
    using System.ComponentModel.DataAnnotations; 
    using System.ComponentModel.DataAnnotations.Schema; 
    using System.Linq; 
    using System.Web;
    
    namespace Memberships.Entities 
    {
        [Table("Item")]
        public class Item
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [MaxLenght(255)]
            [Required]
            public int Id { get; set; }
            [MaxLength(2048)]
            public string Title { get; set; }    
        } 
    }
