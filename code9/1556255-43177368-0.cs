        ...
        // New code:    
        [ForeignKey("User")]
        public Guid userId { get; set; }
        public virtual User User { get; set; }
    }
