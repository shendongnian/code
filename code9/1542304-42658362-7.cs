    class HomeViewModel {
        [DisplayName("First value")]
        [Required]
        public String FirstValue { get; set; }
        [DisplayName("Second value")]
        [Required]
        [Compare( nameof(this.FirstValue), ErrorMessage = "Second value must match First value.")]
        public String SecondValue { get; set; } 
    }
