    public class Window
    {
        public virtual void Break()
        {
            Console.WriteLine("Break in window called");
        }
    }
    public class Glass : Window
    {
        public override void Break()
        {
            Console.WriteLine("Break in Glass called");
        }
        public void DoSomething()
        {
            Break();
            this.Break(); // Same as above line
            base.Break();
        }
    }
