      class Father
        {
            [Key]
            public long Id { get; set; }
        
            public int SonId{get;set;}
            public int DaughterId{get;set;}
           
    
            [ForeignKey("SonId")]
            public virtual Child Child_Son{get;set;}
    
            [ForeignKey("DaughterId")]
            public virtual Child Child_Son{get;set;}
        }
        
        class Child
        {
            [Key]
            public long Id { get; set; }
        
            public string Gender{get;set;}
        }
