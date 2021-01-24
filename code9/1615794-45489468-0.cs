    [Table("People67")]
    public class Person
    {
        public Person()
        {
            Children = new List<Person>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual Info Info { get; set; }
        public virtual ICollection<Person> Children { get; set; }
    }
    public class Info
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
    }
