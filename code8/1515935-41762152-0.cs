    public class ClassToTest {
        public int Numer { get; private set; }
        public void func() {
            this.Number = 25;
        }
    }
    
    Public class MyProgram {
        public static void Main() {
            ClassToTest instance = new ClassToTest();
            instance.func();
            var i = instance.Number;
        }
    }
