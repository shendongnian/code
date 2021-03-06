    [Key]
    public Guid Id { get; set; }
    [ForeignKey("Parent")]
    public Guid ParentId { get; set; } 
    [Required]
    public string Name { get; set; }
    public virtual Role Parent { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Role> Children { get; set; }
