    public abstract class BaseClass
    {
        private Timer _timer;
        protected BaseClass()
        {
            _timer = new Timer();
            _timer.Tick += (sender, args) => 
           {
              Console.WriteLine("Calling Update."); 
              Update();
           };
            _timer.Interval = 1000;
            _timer.Start();            
        }
        protected abstract void Update();
    }
    public class InheritedClass : BaseClass
    {
        protected override void Update()
        {
            Console.WriteLine("Update was called.");
        }
    }
