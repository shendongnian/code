    public class myPackage
    {
        public int Id;
        public myPackage(int id)
        {
            this.Id = id;
        }
    }
    class program
    {
        static void Main()
        {
            var source = new[] { 0, 1, 2, 3, 4, 5, 4, 3 }.ToObservable().Select(i => new myPackage(i));
            var routes = source.RouteData(e => e.Id);
            var subscription = new CompositeDisposable(
                routes.Get(5).Subscribe(Console.WriteLine),
                routes.Get(4).Subscribe(Console.WriteLine),
                routes.Get(3).Subscribe(Console.WriteLine),
                routes.Connect());
            Console.ReadLine();
        }
    }
