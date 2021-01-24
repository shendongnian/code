	public class Members
	{
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "someDisplayName")]
        public bool ABool{ get; set; }
        public ReferenceClass ReferenceClass { get; set; }
        public int ReferenceClassId { get; set; }
	}
