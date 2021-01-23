            Type someType = typeof(int); // then, try to change this to "typeof(string)"
            Type someTypeNullable = null;
            if (someType.IsValueType)
            {
                someTypeNullable = typeof(Nullable<>).MakeGenericType(someType);
            }
            if (someTypeNullable != null)
            {
                Console.WriteLine("nullable version: " + someType + "?");
            }
            else
            {
                Console.WriteLine(someType + " is a reference type");
            }
 
