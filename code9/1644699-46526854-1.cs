    public class B
    {
        public B(A a)
        {
            a.Evnt += Evnt; // this does not work
        }
        public event Action<string> Evnt = v => { Console.WriteLine("Original"); };
    }
