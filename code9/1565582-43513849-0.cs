    public T GetExample<T>() where T : IExample where T : class,new()
        {
            // Return the signal if it exists
            if (examples.ContainsKey(typeof(T)))
            {
                IExample value;
    
                if (!examples.TryGetValue(typeof(T), out value))
                {
                    // unable to get value
                }
    
                return (T)value;
            }
    
            // Stuck on this line here. How exactly do I instantiate a new example if it doesn't exist.
            T obj =  new T(); // create instance of T and use further down in code it's reference
            examples.Add(typeof(T),obj );
    
            return obj ;
        }
