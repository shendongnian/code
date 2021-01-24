    public static void Main()
    {
        var cb = new ClassB();
        cb.setMethod(ClassA.methodA);
    }
    public class ClassB
    {
        Delegate del;
        public void setMethod(Action<int> action)
        {
            del = new Delegate(action);
        }
        public void ButtonClick()
        {
            var n = 2;
            del.Invoke(n);
        }
    }
    public delegate void Delegate(int n);
