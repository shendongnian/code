          [NotMapped]
          private string _converter { get; set; }
          [Column(TypeName = "char"), StringLength(16)] 
          public string MyProperty 
          {
           get
           {
             return this._converter;
           }
           set
           {
             this._converter = Convert.ToString(value);
           }
          }
  
