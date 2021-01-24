      public class Foo {
        public void Execute() { }
      }
    
      public class Bar<T> where T : Foo { //constrained generic
        public T val;
        public Bar(T input){
          val = input;
        }
        public void SomeFunction() {
          val.Execute(); //generic is better since it can call this "Execute" method without Reflection
        }
      }
