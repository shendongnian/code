    public class EventTest
    {
        void SomeOperation()
        {
            //Do something
        }
        public void Run()
        {
            SomeOperation();
            RunFinished?.Invoke(this, EventArgs.Empty); //Invoke the event, indicating that something has happened or finished
        }
        //The event itself
        public event EventHandler RunFinished;
    }
    public class EventSubscriber
    {
        EventTest _ET = new EventTest();
        public EventSubscriber()
        {
            _ET.RunFinished += ETRunFinished; //Register my method, called when the event occurs (is invoked)
        }
        public void DoSomething()
        {
            _ET.Run();
            Console.WriteLine("Something completed.");
        }
        void ETRunFinished(object sender, EventArgs e)
        {
            Console.WriteLine("My event handler was executed.");
        }
    }
