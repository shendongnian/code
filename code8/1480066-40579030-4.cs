    class Program
    {
        static void Main(string[] args)
        {
            Class[] classInstances =
            {
                new Class("A"),
                new Class("B"),
                new Class("C"),
            };
            foreach (Class c in classInstances)
            {
                string methodName = c.Name + "_Event";
                MethodInfo mi = typeof(Program).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
                EventHandler handler = (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), mi);
                c.Event += handler;
            }
            foreach (Class c in classInstances)
            {
                c.RaiseEvent();
            }
        }
        static void A_Event(object sender, EventArgs e) { Console.WriteLine("A_Event handler"); }
        static void B_Event(object sender, EventArgs e) { Console.WriteLine("B_Event handler"); }
        static void C_Event(object sender, EventArgs e) { Console.WriteLine("C_Event handler"); }
    }
    class Class
    {
        public string Name { get; }
        public Class(string name)
        {
            Name = name;
        }
        public event EventHandler Event;
        public void RaiseEvent()
        {
            Event?.Invoke(this, EventArgs.Empty);
        }
    }
