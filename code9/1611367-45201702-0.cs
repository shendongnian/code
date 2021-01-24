    public delegate void DelegateMyDeler(); //This is a custom delegate
    public class MyClass
    {
        public DelegateMyDeler MyDeler; //This use your custom delegate
        public Action MyVoidAction; // This use Action delegate
    }
    class MainClass
    {
        static void Main()
        {
            // MyClass.MyDeler d = () => Console.WriteLine("my deler"); // Now this is not allowed too!
            // d();
            //  MyClass.MyVoidAction mva1 = () => Console.WriteLine("my void action"); // not allowed, why?
            MyClass meClass = new MyClass();
            meClass.MyDeler = () => Console.WriteLine("my deler");
            meClass.MyDeler();
            meClass.MyVoidAction = () => Console.WriteLine("my void action");
            meClass.MyVoidAction();
            //but you can do (you custom delegate is defined out of the class in this case
            //so you have not to add the class prefix):
            DelegateMyDeler d = () => Console.WriteLine("my deler 2");
            d();
            // or
            DelegateMyDeler d3 = () => Console.WriteLine("my deler 3");
            d3.Invoke();
            // and in a real case, for example:
            DelegateMyDeler undeterminedMethod;
          
            int x = 3;
            switch (x)
            {
                case 1:
                    undeterminedMethod = deler1;
                    break;
                case 2:
                    undeterminedMethod = deler2;
                    break;
                case 3:
                    undeterminedMethod = deler3;
                    break;
                default:
                    undeterminedMethod = null;
                    break;
            }
            undeterminedMethod?.Invoke(); //In case x is minor than 1 or major than 3, nothing happens
        }
        static void deler1() { Console.WriteLine("my deler 1"); }
        static void deler2() { Console.WriteLine("my deler 2"); }
        static void deler3() { Console.WriteLine("my deler 3"); }
    }
