    public class FooService : IFooService 
    {
        public CountryService()
        {
        }
    
        public IEnumerable<Foo> GetAll()
        {
            using (var context = new Context())
            {
                return context.Foo.ToList();
            }
        }
    }
