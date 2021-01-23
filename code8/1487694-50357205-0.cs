    void Main()
    {
      var Ids = 0;
      var test = new Faker<Person>()
          .RuleFor(p => p.Id, f => Ids++)
          .RuleFor(p => p.Phones, f => f.Make(3, () => f.Phone.PhoneNumber()));
          //If you want a variable number of phone numbers
          //in the list, replace 3 with f.Random.Number()
      test.Generate(5).Dump();
    }
    
    public class Person
    {
      public int Id { get; set; }
      public List<string> Phones { get; set; }
    }
