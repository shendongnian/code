    public static class ObjectExtensions
    {
        public static bool IsDefaultValue<TObject>(this TObject @object)
        {
            return EqualityComparer<TObject>.Default.Equals(@object, default(TObject));
        }
    }
