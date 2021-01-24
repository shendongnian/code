    public static IEnumerable<MyClass> WhereDefaulted(this IEnumerable<MyClass> src, Func<MyClass,bool> predicate)
    {
         return src.Where(x => predicate(x) && 
                               x.Some.Property == "someValue" &&
                               x.Other.Property == 12);
    }
 
