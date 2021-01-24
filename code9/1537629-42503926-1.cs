    class BaseConverter
    {
        protected T Convert<T, X>(X result)
        {
            var derivedClassInstance = Activator.CreateInstance<T>();
            var derivedType = derivedClassInstance.GetType();
    
            var properties = result.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propToSet = derivedType.GetProperty(property.Name);
                if (propToSet.SetMethod != null)
                {
                    propToSet.SetValue(derivedClassInstance, property.GetValue(result));
                }
            }
            return derivedClassInstance;
        }
    
        protected List<T> Convert<T, X>(List<X> listResult)
        {
            var derivedList = new List<T>();
            foreach (var r in listResult)
            {
                //can cope with this - since there will not ever be many iterations
                derivedList.Add(Convert<T, X>(r));
            }
            return derivedList;
        }
    }
