    ///<summary>
    /// Converts the value that is encapsulated by this result to the specified type.
    ///</summary>
    public static class ValueProviderResultExtension {
        public static T ConvertTo<T>(this ValueProviderResult valueProvider) {
            return (T) valueProvider.ConvertTo(typeof(T));
        }
    }
