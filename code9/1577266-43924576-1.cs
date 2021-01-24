     public class Person
     {
         public int Id { get; set; }
         public string Name { get; set; }
         public virtual Country Country { get; set; }
         public int Country_Id { get; set; }
     }
     // ...
     // Change country
     p.Country = new Country() { Id = 2, Name = "Canada" };
     p.Country_Id = 2;
