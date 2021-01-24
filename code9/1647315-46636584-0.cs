     public class StavkaNarudzbe : IEntity
        {
            public int Id { get; set; }
            public bool IsDeleted { get; set; }
            public string Naziv { get; set; }
            public int Tezina { get; set; }
            public double Cijena { get; set; }
            public int Narudzbe_Id { get; set; }
            [ForeignKey("Narudzbe_Id")]
            public virtual Narudzbe Narudzbe { get; set; }
        }
