    public class TextPropertyBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi == null || pi.Name != "Text" || pi.PropertyType != typeof(string))
                return new NoSpecimen();
            return "Foo";
        }
    }
