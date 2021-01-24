    using System;
    public interface I1<U> {
        void M(U i);
        void M(int i);
    }
    
    public interface I2<U> {
        void M(int i);
        void M(U i);
    }
    
    public class C3: I1<int>, I2<int> {
        void I1<int>.M(int i) {
            Console.WriteLine("c3 explicit I1 " + i);
        }
        void I2<int>.M(int i) {
            Console.WriteLine("c3 explicit I2 " + i);
        }
        public void M(int i) { 
            Console.WriteLine("c3 class " + i); 
        }
    }
    
    public class Test {
        public static void Main() {
            C3 c3 = new C3();
            I1<int> i1_c3 = c3;
            I2<int> i2_c3 = c3;
            i1_c3.M(101);
            i2_c3.M(102);
        }
    }
