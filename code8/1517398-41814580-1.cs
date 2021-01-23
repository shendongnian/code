    using MyApp.Utils.Validation;
    
    {
       [CustomAttributeNoGuidEmpty]
       public Guid Id { get; set; }
      
       [Required]
       public string Name { get; set; }
    }
