    public class CountryWithCapital
    {
      publict string Country {get;set;}
      public string Capital {get;set;}
      public CountryWithCapital(){}//Empty default constructor 
      public CountryWithCapital(string Country, string Capital)
      {
        this.Country=Country;
        this.Capital=Capital;
      }
    }
    
    //Implementation.
    var CountriesWithCapitals=new List<CountryWithCapital>();
    CountriesWithCapitals.Add(new CountryWithCapital("here is your country","this is your capital")); //Repeat this n times you want.
    var Number=new Random().Next(0,5);
    Console.WriteLine("Country :{0}, Capital :{1}",CountriesWithCapitals[Number].Countrry, CountriesWithCapitals[Number].Capital);
