    public class CachingValueRepositoryDecorator : IValueRepository
    {
        private readonly Lazy<SomeValues> values;
        public CachingValueRepositoryDecorator(IValueRepository decoratee)
        { 
            this.values = new Lazy<SomeValues>(decoratee.GetSomeValues);
        }
        public SomeValues GetSomeValues() => this.values.Value;
    }
