    public static List<PersonRecord> Parse(string records)
    {
       var splits = records.Split('|');
       var persons = splits.Select(p =>
       {
          int age;
          var split = p.Split('=');
          if(int.TryParse(split[0], out age))
          {
             return new PersonRecord { MinAge = age, Maturity = split[1] };
          }
    
          // Age was not a number so so whatever you want here
          // Or you can return a dummy person record
          throw new InvalidOperationException("Records is not valid.");
    
       }).ToList();
    
       return persons;
    }
