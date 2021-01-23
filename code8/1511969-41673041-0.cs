    public class ExcludeUnknownEnumGenerator : ISpecimenBuilder
    {
        private readonly EnumGenerator _enumGenerator = new EnumGenerator();
        public object Create(object request, ISpecimenContext context)
        {
            var speciment = _enumGenerator.Create(request, context);
            if (speciment.ToString() == "Unknown" ||
                speciment.ToString() == "Uninitialized")
            {
                speciment = _enumGenerator.Create(request, context);
            }
            return speciment;
        }
    }
    public enum EnumWithUnknown
    {
        Known,
        Unknown,
        Wellknown,
        Uninitialized
    }
