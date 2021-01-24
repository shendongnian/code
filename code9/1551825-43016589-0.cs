    public class Eventable
    {
        public event Action<Eventable, int> OnMagic;
        public void Magic(int i)
        {
            OnMagic?.Invoke(this, i);
        }
        public void RegisterMagic(Action<Eventable, int> action)
        {
            Action<Eventable, int> _action = null;
            _action = (_e, i) =>
            {
                action(_e, i);
                OnMagic -= _action;
            };
            OnMagic += _action;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Eventable e = new Eventable();
            e.RegisterMagic((ev, i) => Console.WriteLine(i));
            e.RegisterMagic((ev, i) => Console.WriteLine(i * i));
            e.Magic(4);
            e.Magic(5);
        }
    }
    Output:
        4
        16
