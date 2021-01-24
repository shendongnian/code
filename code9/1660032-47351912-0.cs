     public static class DeepCloneHelper
    {
        private static string[] _excludedPropertyNames = null;
        /// <summary>
        /// Get the deep clone of an object.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">It is the object used to deep clone.</param>
        /// <param name="propertyNames"></param>
        /// <returns>Return the deep clone.</returns>
        public static T DeepClone<T>(T source, string[] propertyNames = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Object is null");
            }
            if (propertyNames != null) { _excludedPropertyNames = propertyNames; }
            return (T)CloneProcedure(source, new Dictionary<object, object>());
            // return target;
        }
        /// <summary>
        /// The method implements deep clone using reflection.
        /// </summary>
        /// <param name="source">It is the object used to deep clone.</param>
        /// <param name="cloned"></param>
        /// <returns>Return the deep clone.</returns>
        private static object CloneProcedure(Object source, Dictionary<object, object> cloned)
        {
            if (source == null)
            {
                return null;
            }
            object clone;
            if (cloned.TryGetValue(source, out clone))
            {
                // this object has been cloned earlier, return reference to that clone
                return clone;
            }
            Type type = source.GetType();
            // If the type of object is the value type, we will always get a new object when 
            // the original object is assigned to another variable. So if the type of the 
            // object is primitive or enum, we just return the object. We will process the 
            // struct type subsequently because the struct type may contain the reference 
            // fields.
            // If the string variables contain the same chars, they always refer to the same 
            // string in the heap. So if the type of the object is string, we also return the 
            // object.
            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            {
                return source;
            }
            // If the type of the object is the Array, we use the CreateInstance method to get
            // a new instance of the array. We also process recursively this method in the 
            // elements of the original array because the type of the element may be the reference 
            // type.
            else if (type.IsArray)
            {
                Type typeElement = Type.GetType(type.FullName.Replace("[]", string.Empty) + "," + type.Assembly.FullName);
                var array = source as Array;
                Array copiedArray = Array.CreateInstance(typeElement, array.Length);
                cloned[source] = copiedArray;
                for (int i = 0; i < array.Length; i++)
                {
                    // Get the deep clone of the element in the original array and assign the 
                    // clone to the new array.
                    copiedArray.SetValue(CloneProcedure(array.GetValue(i), cloned), i);
                }
                return copiedArray;
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                if (typeof(IList).IsAssignableFrom(type))
                {
                    var collection = (IList)Activator.CreateInstance(type);
                    cloned[source] = collection;
                    foreach (var element in source as IEnumerable)
                    {
                        collection.Add(CloneProcedure(element, cloned));
                    }
                    return collection;
                }
                else if (type.IsGenericType)
                {
                    var objectType = type.GetGenericArguments().Single();
                    if (typeof(IList<>).MakeGenericType(objectType).IsAssignableFrom(type) ||
                        typeof(ISet<>).MakeGenericType(objectType).IsAssignableFrom(type))
                    {
                        var collection = Activator.CreateInstance(type);
                        cloned[source] = collection;
                        var addMethod = collection.GetType().GetMethod("Add");
                        foreach (var element in source as IEnumerable)
                        {
                            addMethod.Invoke(collection, new[] { CloneProcedure(element, cloned) });
                        }
                        return collection;
                    }
                }
                return source;
            }
            // If the type of the object is class or struct, it may contain the reference fields, 
            // so we use reflection and process recursively this method in the fields of the object 
            // to get the deep clone of the object. 
            // We use Type.IsValueType method here because there is no way to indicate directly whether 
            // the Type is a struct type.
            else if (type.IsClass || type.IsValueType)
            {
                object copiedObject = Activator.CreateInstance(source.GetType());
                cloned[source] = copiedObject;
                // Get all PropertyInfo.
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (PropertyInfo property in properties)
                {
                    if (_excludedPropertyNames == null || !_excludedPropertyNames.Contains(property.Name))
                    {
                        object propertyValue = property.GetValue(source);
                        if (propertyValue != null && property.CanWrite && property.GetSetMethod() != null)
                        {
                            // Get the deep clone of the field in the original object and assign the 
                            // clone to the field in the new object.
                            property.SetValue(copiedObject, CloneProcedure(propertyValue, cloned));
                        }
                    }
                }
                return copiedObject;
            }
            else
            {
                throw new ArgumentException("The object is unknown type");
            }
        }
    }
