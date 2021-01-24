    public class FooBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            return request.Equals(typeof(string))
                ? (object)"foo"
                : new NoSpecimen();
        }
    }
