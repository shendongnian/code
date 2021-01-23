    class GuessingName
    {
      public GuessingName(string name){Name = name;}
      public string Name;
      public bool chosen;
    }
    class RandomNamePicker{
     private List<GuessingName> names;
     public RandomNamePicker(){
      names = new List<GuessingName>();
      names.Add(new GuessingName("movie"));
     }
     string RandomPicker(){
      
      if(names.All(c=>c.chosen))
        names.ForEach(c=>c.chosen=false);
      int r1 = r.Next(0, names.Length);
      
      while(names[r1].chosen){
       r1= r.Next(0,names.Length);
      }
      return names[r1].Name;
     }
    }
