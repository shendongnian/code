    class Test
    {
     private readonly string name;
     public string Name { get { return name; } }
     public Test()
     {
      name = "Hello World!";
     }
     public Test(string name)
     {
      this.name = name; //You use this to set scope to the object to disambiguate name
     }
    }
