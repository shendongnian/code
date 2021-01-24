    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace MVCef.Models
    {
        [Table("MyFlashCard")]
        public class MyFlashCard
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public MyFlashCard()
            {
                MyFlashCardPics = new HashSet<MyFlashCardPic>();
            }
            public int Id { get; set; }
    
            public int? FaslID { get; set; }
    
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<MyFlashCardPic> MyFlashCardPics { get; set; }
        }
    
        [Table("MyFlashCardPic")]
        public class MyFlashCardPic
        {
            public int Id { get; set; }
    
            public virtual MyFlashCard MyFlashCard { get; set; }
        }
    }
