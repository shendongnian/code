    public class MyClass<T> where T : new()
    { 
        public Task<List<T>> getDB()
        {
            ...
        }
    }
