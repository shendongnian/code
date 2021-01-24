      public class Foo {
        public void Execute() { }
      }
    
      public class Bar<T> where T : Foo { //constrained generic
        public void Func(T obj) {
          obj.Execute(); //generic is better since it can call this "Execute" method without Reflection
        }
      }
