    T GetOrCreateForm<T> where T: UserForm, new()
    {
        UserForm f = cache.OfType<T>().FirstOrDefault();  //Search cache
        if (f == default(T))                              //If not found,
        {
            f = new T();                                  //Create it anew
            cache.Add(f);                                 //and add it to the cache
        }
        return f;                                         //return the form we just created/retrieved
    }
