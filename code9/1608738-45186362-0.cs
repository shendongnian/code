    public class ImmutableListSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var t = request as Type;
            if (t == null)
            {
                return new NoSpecimen();
            }
            var typeArguments = t.GetGenericArguments();
            if (typeArguments.Length != 1 || typeof(ImmutableList<>) != t.GetGenericTypeDefinition())
            {
                return new NoSpecimen();
            }
            dynamic list = context.Resolve(typeof(IList<>).MakeGenericType(typeArguments));
            return ImmutableList.ToImmutableList(list);
        }
    }
