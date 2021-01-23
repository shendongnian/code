    public static IEnumerable GetEntities()
            {
                int [] arr = {1,2,3};
    
                return arr.SelectMany(Xenv =>
                     Enumerable.Range(0, 7).Select(a => new SomeEntity(someFunction(a)))
                    );
            }
