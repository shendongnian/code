        [Required]
        [InverseProperty("Parts")]
        public virtual T Component { get; set; }
        [InverseProperty("Variants")]
        public virtual ICollection<T> PartOf { get; set; }
