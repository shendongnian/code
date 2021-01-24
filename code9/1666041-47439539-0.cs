    public static class Extensions
    {
        //  nuget Install-Package "System.ValueTuple" if the compiler gives you any backtalk
        public static List<(String Name, Type Type, Object Value)> GetPublicPropertiesWithValues(this object obj)
            => obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(p => (Name: p.Name, Type: p.PropertyType, Value: p.GetValue(obj)))
                .ToList();
    }
