    public class X
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
    
        // you don't need Token here...
        //public string Token { get; set; }
        [InverseProperty("X")]
        public virtual Y Y { get; set; }
    }
    public class Y
    {
        [Key, Column(Order=1)]
        public long XId {get;set;}
        [Key, Column(Order=2) StringLength(64)] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Token { get; set; }
        [ForeignKey("XId")]
        [InverseProperty("Y")]
        public virtual X X{ get; set; }
    }
