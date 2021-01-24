    public class Application 
    {
        private List<Developer> _Developers; 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Note { get; set; }
        [Required(ErrorMessage="The Id Of Owner(owner as a developer) is Required")]
        public int DeveloperId { get; set; } 
        [ForeignKey("DeveloperId")]
        public virtual Developer Owner { get; set;}
        public virtual List<Developer> Developers { get{return _Developers;}} // This create Many to many
        public application(){
            _Developers= new List<Developer>();
        }
    }
