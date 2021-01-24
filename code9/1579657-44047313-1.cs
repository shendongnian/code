    public class BarService : IBarService
    {
        private readonly IFoo _foo;
        public BarService(IFoo foo)
        {
            this._foo = foo;
        }
    }
