    public abstract class Base<T> {
       public abstract T Value
       {
          get;
          set;
       }
    }
    
    public class Derived1 : Base<int> {
       public override int Value { get; set; }
    }
    
    public class Derived2 : Base<float> {
       public override float Value { get; set; }
    }
    
    public class Factory {
       public Base<T> Create<T>(int type) {
          switch( type ) {
             case 1:
             return new Derived1() as Base<T>;
             case 2:
             return new Derived2() as Base<T>;
          }
    
          return null; // or whatever you want to do
       }
    }
