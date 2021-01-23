    public class ExcludeUnknownEnumGenerator : ISpecimenBuilder
    {
        private readonly EnumGenerator _enumGenerator = new EnumGenerator();
        public object Create(object request, ISpecimenContext context)
        {
            var enumType = request as Type;
            if (enumType == null || !enumType.IsEnum)
            {
                return new NoSpecimen();
            }
            var namesEnumerator = Enum.GetNames(enumType).GetEnumerator();
            while (namesEnumerator.MoveNext())
            {
                var specimen = _enumGenerator.Create(request, context);
                if (specimen.ToString() != "Unknown" &&
                    specimen.ToString() != "Uninitialized")
                {
                    return specimen;
                }
            }
            throw new ObjectCreationException(
                "AutoFixture was unable to create a value for " +
                enumType.FullName +
                " since it is an enum containing either no values or " +
                "ignored values only ('Unknown' and 'Uninitialized'). " +
                "Please add at least one valid value to the enum.");
        }
    }
    public enum EnumWithUnknown
    {
        Known,
        Unknown,
        Wellknown,
        Uninitialized
    }
