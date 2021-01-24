    public class student
    {
            [Key]
            public int studentid { get; set; }
            public string emristudent { get; set; }
            public int nota { get; set; } 
            public int klasaid {get;set;}
            [ForeignKey("klasaid")]
            public klasa Klasa{ get; set; }
    }
