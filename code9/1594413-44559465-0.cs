    class Program
    {
        public static void Main()
        {
            int n = 2;
            ClassB cb = new ClassB();
    
            cb.setMethod(() => ClassA.methodA(n));
    
        }
    }
    
    public class ClassA
    {
        public static void methodA(int a)
        {
            //code
        }
    }
    
    public class ClassB
    {
        Delegate del;
        public void setMethod(Action action)
        {
            del = new Delegate(action);
        }
        public void ButtonClick()
        {
            del.Invoke();
        }
    }
    public delegate void Delegate();
