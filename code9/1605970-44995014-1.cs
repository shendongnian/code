    class class2<T>
    {
       private Func<class1, T> getValue;
       public class2(Func<class1, T> getValue)
       {
           this.getValue = getValue;
       }
       public void Add(class1 cs)
       {
           // Something like this
           var val = this.getValue(class1);
           // do something with val
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            class1 c1 = new class1(1, 2);
            // create the Func as a lambda and pass to the constructor.
            class2<int> c2 = new class2<int>(c => c.getp1)
        }
    }
