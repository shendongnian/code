        static void Main(string[] args)
        {
                var list = new List<Class1>();
                var class1 = new Class1 {P1 = "P1-1", P2 = "P2-1", P3 = "null"};
                list.Add(class1);
                var class2 = new Class1 {P1 = "P1-2", P2 = "P2-2", P3 = "null"};
                list.Add(class2);
               var updatedList=  ReplaceValues(list, "null", string.Empty);
        }
        private static IEnumerable<TSource> ReplaceValues<TSource>
        (IEnumerable<TSource> source, object oldValue,
        object newValue)
        {
            var properties = typeof(TSource).GetProperties();
            var sourceToBeReplaced = source as TSource[] ?? source.ToArray();
            foreach (var item in sourceToBeReplaced)
            {
                foreach (var propertyInfo in properties.Where(t => Equals(t.GetValue(item), oldValue)))
                {
                    propertyInfo.SetValue(item, newValue);
                }
            }
            return sourceToBeReplaced;
        }
