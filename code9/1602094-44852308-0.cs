    public void Main()
    {
       var animals = NewRange<Animal>(0, 100);
    }
    
    public static List<T> NewRange<T>(int n, int b)
    {
       return (List<T>)Enumerable.Range(0, 100).Select(instance => (T)Activator.CreateInstance(typeof(T))).ToList();
    }
