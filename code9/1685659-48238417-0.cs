    public class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fathername { get; set; }
        public string email { get; set; }
        public string Company_name { get; set; }    
    } 
