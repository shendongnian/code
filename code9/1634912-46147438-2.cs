    public static class SingletonFactory
    {
        private static readonly object lockObject = new object();
        //Dictionary to store the singleton objects 
        private static readonly Dictionary<string, object> singletonObjects = new Dictionary<string, object>();
        // Method to retrieve singleton instance.
        // Note the constraint "new ()". This indicates that this method can be called for the types which has default constructor.
        public static T GetSingletoneInstance<T>() where T:new ()
        {
            var typeName = typeof(T).Name;
            T instance;
            lock (lockObject)
            {
                // Check in the dictionary if the instance already exist.
                if (singletonObjects.ContainsKey(typeName))
                {
                    //Retrieve the instance from the dictionary.
                    instance = (T) singletonObjects[typeName];
                }
                else
                {
                    // If it does not exist in the dictionary, 
                    // create a new instance 
                    // and store it in the dictionary.
                    lock (lockObject)
                    {
                        instance = new T();
                        singletonObjects.Add(typeName, instance);
                    }
                }
            }
            // Return the instance of type "T" either retrieved from dictionary 
            // or the newly created one.
            return instance;
        }
    }
