        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
        public class ExcludeBindAttribute : Attribute, IModelNameProvider, IPropertyFilterProvider
        {
            private static readonly Func<ModelMetadata, bool> _default = (m) => true;
    
            private Func<ModelMetadata, bool> _propertyFilter;
    
            public string[] Exclude { get; }
            
            public string Prefix { get; set; }
    
            public ExcludeBindAttribute(params string[] exclude)
            {
                var items = new List<string>();
                foreach (var item in exclude)
                {
                    items.AddRange(SplitString(item));
                }
    
                Exclude = items.ToArray();
            }
    
            public string Name
            {
                get { return Prefix; }
            }
    
            public Func<ModelMetadata, bool> PropertyFilter
            {
                get
                {
                    if (Exclude != null && Exclude.Length > 0)
                    {
                        if (_propertyFilter == null)
                        {
                            _propertyFilter = (m) => !Exclude.Contains(m.PropertyName, StringComparer.Ordinal);
                        }
    
                        return _propertyFilter;
                    }
                    else
                    {
                        return _default;
                    }
                }
            }
    
            private static IEnumerable<string> SplitString(string original)
            {
                if (string.IsNullOrEmpty(original))
                {
                    return Array.Empty<string>();
                }
    
                var split = original.Split(',').Select(piece => piece.Trim()).Where(piece => !string.IsNullOrEmpty(piece));
    
                return split;
            }
        }
