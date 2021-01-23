    if (!typeDictionary.ContainsKey(typeof(T)))
    {
        lock(lockObj) 
        {
            if (!typeDictionary.ContainsKey(typeof(T)))
            {
                typeDictionary.Add(type, type.GetProperties().ToList());
            }
        }
    }
