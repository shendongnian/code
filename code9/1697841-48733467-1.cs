    class Class1 {
       List<Class2> classes = new List<Class2>();
    
       public IEnumerable<string> Values {
          get { return classes.Select(cls => cls.Property); }
       }
    
       public void AddClass(Class2 cls) {
          classes.Add(cls);
       }
    }
