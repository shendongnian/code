     using System.ComponentModel.DataAnnotations.Schema;
    .
    .
    .
    [ForeignKey("CountryForeignKey")]
            public Country Country { get; set; }
    
            public string CountryForeignKey { get; set; } 
