    public class MyService
    {
        public void DoSomething()
        {
            DataContext dc = new DataContext(); // concrete
            var c = new MyClass(dc);
        }
    }
