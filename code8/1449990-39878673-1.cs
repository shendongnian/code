    [assembly: Dependency(typeof(PclWorkaround))]
    class PclWorkaround : IPclWorkaround
    {
        public object ConvertFromInvariantString(Type type, string s)
        {
            return TypeDescriptor.GetConverter(type).ConvertFromInvariantString(s);
        }
    }
