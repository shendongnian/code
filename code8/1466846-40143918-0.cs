        public class Base {
            public int ID { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "Name")]
            public string Name { get; set; }
        }
        public class Derived : Base {
            [Key]
            public int projectId {get; set; }
        }
