    public static IEnumerable GetEntities()
        {
            int [] arr = {1,2,3};
            foreach (int i in arr)
            {
                //        for (int i = 0; i < someArray.Count();i++)
                //            yield return new SomeEntity(someFunction(i));
                // *** Equivalent linq function ***    
                return Enumerable.Range(0, 7).Select(a => new SomeEntity(someFunction(a)));
            }
            //INSERT RETURN STATEMENT HERE
        }
