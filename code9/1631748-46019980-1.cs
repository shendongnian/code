    public class ClassA
    {
        [Index(IsUnique = true)]
        [MaxLength(200)]
        public String AId { get; set; }
        public virtual List<AB> AB { get; set; }
        public List<ClassC> C { get; set; }
    }
    public class ClassB
    {
        public int BId { get; set; }
        public virtual List<AB> AB { get; set; }
    }
    public class AB
    {
        public int Id { get; set; }
        [Required]
        public virtual A A { get; set; }
        [Required]
        public virtual B B { get; set; }
        [MaxLength(200)]
        public string AId { get; set; }
        public int BId { get; set; }
    }
    public class ClassC
    {
        public int CId { get; set; }
        public ClassA A { get; set; }
        public int AId { get; set; }
    }
