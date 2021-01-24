    public class Person
    {
        private PersonContext context;
 
        [Key]
        public int Id { get; set; }
 
        public string Imie { get; set; }
 
        public DateTime Uro { get; set; }
 
        public string Pass { get; set; }
       public Person(int _Id,string _Imie,DateTime _Uro,string _Pass )
       {
          this.Id=_Id;
          this.Imie=_Imie;
          this.Uro=_Uro;
          this.Pass=_Pass;
       }
    }
