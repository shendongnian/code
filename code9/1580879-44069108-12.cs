    class Program
    {
        static event Action<int> eventTest;
        static void Main(string[] args)
        {
            var aggregate = new AggregateView();
            eventTest += aggregate.Listener;
            aggregate.Views.Subscribe(ReceiveList);
            aggregate.Events.Subscribe(ReceiveValue);
            eventTest(1);
            eventTest(2);
            eventTest(3);
            eventTest(4);
            eventTest(5);
            aggregate.RequestView();
            aggregate.Complete();
            eventTest(6);
            eventTest(7);
            eventTest(8);
            eventTest(9);
            eventTest(10);
            aggregate.RequestView();
        }
        static void ReceiveList(Lst<int> list) =>
            Console.WriteLine($"Got list of {list.Count} items: {ListShow(list)}");
        static void ReceiveValue(int x) =>
            Console.WriteLine(x);
        static string ListShow(Lst<int> list) => 
            String.Join(", ", list);
    }
