    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var x = new EventManager<Partner>();
        }
    }
    public class EventManager<T>
    {
        List<BaseEvent<T>> baseEvents = new List<BaseEvent<T>>();
    }
    public class BaseEvent<T>
    {
    }
    public class MyEvent<T> : BaseEvent<T>
    {
    }
    public class Partner
    {
    }
