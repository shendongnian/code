    public T GetExample<T>() where T : IExample,class,new()
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
    
       T obj =  new T(); // create instance of T and use further down in code it's reference
       examples.Add(typeof(T),obj );
    
       return obj ;
    }
