        public class Car {
         int a;
         int b;
         public List<string> propNames;
    
         public Car()
         {
             a = b = 0;
             propNames = new List<string>();
         }
    
         public Car(int a, int b)
         {
             this.a = a;
             this.b = b;
         }
    
         public int A {
             set { a = value; }
             get { return a; }
         }
    
         public int B {
             set { b = value; }
             get { return b; }
         }
    }
