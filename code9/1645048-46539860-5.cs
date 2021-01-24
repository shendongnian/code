    //Helper extension method
    public static IEnumerable<T> ToEnumerable<T>(this T item)
    {
        yield return item; 
    }
    //Then just have one prototype
    public object foo(List<bar>)
    {
        //some code
    }
    //But call it like this if you want
    var result = foo(bar.ToEnumerable());
