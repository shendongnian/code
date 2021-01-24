    public class MainObject<TRef, TProp> where TProp : struct
    {
        public TRef Reference { get; set; }
        public TProp? Value { get; set; }
        public bool SelfDuplicate { get; set; }
        
    }
    
    public static class Extensions
    {
        public static IEnumerable<MainObject<TIn, TProp>> GetDuplicates<TIn, TProp>(this IEnumerable<TIn> @this) where TProp : struct
        {
            var type = typeof(TIn);
            // get the properties of the object type that match the property type
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(prop => prop.PropertyType == typeof(TProp) || prop.PropertyType == typeof(TProp?)).ToList();
            // convert the input enumerable to a list so we don't iterate it multiple times
            var list = @this as IList<TIn> ?? @this.ToList();
            // create a list to hold all duplicates
            var duplicates = new List<MainObject<TIn, TProp>>();
            foreach (var item1 in list)
            {
                var isSelfDupe = item1.IsDuplicate<TIn, TProp>(props);
                if (isSelfDupe.IsDupe)
                {
                    duplicates.Add(new MainObject<TIn, TProp>
                    {
                        Reference = item1,
                        SelfDuplicate = true,
                        Value = (TProp?)isSelfDupe.Property1.GetValue(item1)
                    });
                }
                foreach (var item2 in list)
                {
                    if (ReferenceEquals(item1, item2)) continue;
                    var isDuplicate = item1.IsDuplicate<TIn, TProp>(item2, props);
                    if (isDuplicate.IsDupe)
                    {
                        duplicates.Add(new MainObject<TIn, TProp>
                        {
                            Reference = item1,
                            SelfDuplicate = false,
                            Value = (TProp?)isDuplicate.Property1.GetValue(item1)
                        });
                    }
                }
            }
            return duplicates.Distinct().ToList();
        }
        private static IsDuplicateResult<TIn> IsDuplicate<TIn, TProp>(this TIn obj1, IEnumerable<PropertyInfo> props) where TProp : struct
        {
            var propList = props as IList<PropertyInfo> ?? props.ToList();
            var valueList = propList.Select(prop => prop.GetValue(obj1)).ToList();
            foreach (var p1 in propList)
            {
                foreach (var p2 in propList)
                {
                    if (ReferenceEquals(p1, p2)) continue;
                    if (EqualityComparer<TProp?>.Default.Equals((TProp?)p1.GetValue(obj1), (TProp?)p2.GetValue(obj1)))
                    {
                        return new IsDuplicateResult<TIn> { IsDupe = true, Reference = obj1, Property1 = p1, Property2 = p2 };
                    }
                }
            }
            return new IsDuplicateResult<TIn> { IsDupe = false };
        }
        private static IsDuplicateResult<TIn> IsDuplicate<TIn, TProp>(this TIn obj1, TIn obj2, IEnumerable<PropertyInfo> props) where TProp : struct
        {
            var propList = props as IList<PropertyInfo> ?? props.ToList();
            var dict1 = propList.ToDictionary(prop => prop, prop => prop.GetValue(obj1));
            var dict2 = propList.ToDictionary(prop => prop, prop => prop.GetValue(obj2));
            foreach (var k1 in dict1.Keys)
            {
                foreach (var k2 in dict2.Keys)
                {
                    if (dict1[k1] == null || dict2[k2] == null) continue;
                    if (EqualityComparer<TProp?>.Default.Equals((TProp?)dict1[k1], (TProp?)dict2[k2]))
                    {
                        return new IsDuplicateResult<TIn> { IsDupe = true, Reference = obj1, Property1 = k1, Property2 = k2 };
                    }
                }
            }
            return new IsDuplicateResult<TIn> { IsDupe = false };
        }
        private class IsDuplicateResult<TIn>
        {
            public bool IsDupe { get; set; }
            public TIn Reference { get; set; }
            public PropertyInfo Property1 { get; set; }
            public PropertyInfo Property2 { get; set; }
        }
    }
