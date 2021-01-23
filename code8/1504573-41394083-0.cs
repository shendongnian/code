    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public Guid ID { get; set; }
        [Display(Name = "Booktitle")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Voornaam")]
        public string AuthorFirstName { get; set; }
        [Required]
        [Display(Name = "Tussenvoegsel")]
        public string AuthorLastName { get; set; }
        
        public string FullName
        {
            get { return CompleteName(); }
        }
        private string CompleteName()
        {
            return this.AuthorFirstName + " " + this.AuthorLastName; 
        }
    }
