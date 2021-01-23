    namespace ConsoleApplication18
    {
      class Program
      {
        static void Main(string[] args)
        {
          var childInstance = Parent.ParseAs<Child>(@"path/to/Afile");
    
          childInstance.SomeAdditionalFunction();
        }
      }
    
      class Parent
      {
        int property;
    
        public static T ParseAs<T>(string filename) where T : Parent, new()
        {
          var parent = new T();
    
          // parse file and set property here...
          parent.property = 42;
    
          return parent;
        }
      }
    
      class Child : Parent
      {
        public void SomeAdditionalFunction() { }
      }
    }
