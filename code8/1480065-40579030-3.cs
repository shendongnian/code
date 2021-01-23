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
            Dictionary<string, EventHandler> nameToHandler =
                    (from mi in typeof(Program).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                     let attribute = (Handler)mi.GetCustomAttribute(typeof(Handler))
                     where attribute != null
                     select new { attribute.Target, mi })
                 .ToDictionary(x => x.Target, x => (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), x.mi));
            foreach (Class c in classInstances)
            {
                c.Event += nameToHandler[c.Name];
            }
            foreach (Class c in classInstances)
            {
                c.RaiseEvent();
            }
        }
        [Handler("A")]
        static void A_Event(object sender, EventArgs e) { Console.WriteLine("A_Event handler"); }
        [Handler("B")]
        static void B_Event(object sender, EventArgs e) { Console.WriteLine("B_Event handler"); }
        [Handler("C")]
        static void C_Event(object sender, EventArgs e) { Console.WriteLine("C_Event handler"); }
    }
    class Handler : Attribute
    {
        public string Target { get; }
        public Handler(string target)
        {
            Target = target;
        }
    }
