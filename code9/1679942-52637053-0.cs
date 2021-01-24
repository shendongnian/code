    using Bogus.Extensions;
    public class ObjectWithNullables
    {
       public int? mynumber{get;set;}
       public decimal? mydec {get;set;}
    }
    
    var faker = new Faker<ObjectWithNullables>()
                // Generate null 20% of the time.
                .RuleFor(x=> x.mynumber, f=>f.Random.Number(10,1000).OrNull(f, .2f))
                // Generate null 70% of the time.
                .RuleFor(x=>x.mydec, f => f.Random.Decimal(8, 10).OrNull(f, .7f));
   
    faker.Generate(10).Dump();
