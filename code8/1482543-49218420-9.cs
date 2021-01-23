    public class Person
    {
        public Person()
        {
            Childern= new HashSet<Person>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [StringLength(50)]
        public string Name{ get; set; }
        public virtual Person Parent { get; set; }
        public virtual ICollection<Person> Children { get; set; }
    }
