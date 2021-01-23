    public partial class Departament
    {
        public Departament()
        {
            this.Person = new HashSet<Person>();
        }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDep { get; set; }
        public string DepName { get; set; }
    
        public virtual ICollection<Person> Person { get; set; }
    }
