    replace this property  in model
    
    add this line above property:[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    
    
    Like this
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
