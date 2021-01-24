    class Class1 {
       List<Class2> classes = new List<Class2>();
    
       public IEnumerable<Class2> Classes {
          get { return classes.AsEnumrable();
       }
    
       public void AddClass(Class2 cls) {
          cls.Lock();
          classes.Add(cls);
       }
    }
    
    class Class2 {
        private string _property;
        private bool _locked;
    
        public string Property {
           get { return _property; }
           set {
              if(_locked) throw new AccessViolationException();
              _property = value;
           }
        }
    
        public void Lock() {
           _locked = true;
        }
    }
