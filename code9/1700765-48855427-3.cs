    public class Foo : IFoo
    {
        private readonly IBarRepository _barRepository;
        public Foo(IBarRepository barRepository)
        {
            _barRepository = barRepository 
                             ?? throw new ArgumentNullException(nameof(fooRepository));
        }
        public void DoSomething()
        {
            // ....
        }
    }
