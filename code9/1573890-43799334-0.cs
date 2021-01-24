    public class SampleClass
    {
        public IDictionary<string, string> Properties { get; }
    }
    private static IList<SampleClass> FilterList(IList<SampleClass> list,
                                                 params Tuple<string, string>[] propertyNames)
    {
        // No point filtering here.
        if (propertyNames == null)
        {
            return list; // or null/empty list if you want to match none as the default.
        }
        // Match All the property values supplied in the filter, you can change this to
        // Contains or string.Equals, etc. to suit your matching needs.
        return list.Where(x => propertyNames.All(p => x.Properties[p.Item1] == p.Item2))
                   .ToList();
    }
