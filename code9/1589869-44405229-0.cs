    class Program
    {
        static void SetPropertyValue<T>(object instance, string name, T value)
        {
            // this is just for example, it would be wise to cache the PropertyInfo's
            instance.GetType().GetProperty(name)?.SetValue(instance, value);
        }
        static void Main(string[] args)
        {
            // create an enumerable which defines the properties
            var properties = new[]
            {
                new DynamicProperty("Name", typeof(string)),
                new DynamicProperty("Age", typeof(int)),
            };
            // create the class type
            var myClassType = ClassFactory.Instance.GetDynamicClass(properties);
            // define a List<YourClass> type.
            var myListType = typeof(List<>).MakeGenericType(myClassType);
            // create an instance of the list
            var myList = (IList)Activator.CreateInstance(myListType);
            // create an instance of an item
            var first = Activator.CreateInstance(myClassType);
            // use the method above to fill the properties
            SetPropertyValue(first, "Name", "John");
            SetPropertyValue(first, "Age", 24);
            // add it to the list
            myList.Add(first);
            var second = Activator.CreateInstance(myClassType);
            SetPropertyValue(second, "Name", "Peter");
            SetPropertyValue(second, "Age", 38);
            myList.Add(second);
        }
    }
