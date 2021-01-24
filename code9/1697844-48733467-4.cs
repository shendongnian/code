    class Class2ReadOnly {
       private Class2 _master;
    
       public Class2ReadOnly(Class2 master) {
          _master = master;
       }
    
       public string Property {
          get { return _master.Property; }
       }
    }
    class Class1 {
       List<Class2ReadOnly> classes = new List<Class2ReadOnly>();
    
       public IEnumerable<Class2ReadOnly> Classes {
          get { return classes.AsEnumerable(); }
       }
    
       public void AddClass(Class2 cls) {
          classes.Add(new Class2ReadOnly(cls));
       }
    }
