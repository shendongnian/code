    namespace ExtensionMethod  
        {
            public static class MyExtensions
            {
                public static Type GetNullabeType(this Type t, string typeName)
                {
                    string typeString = typeName;
                    var typeNonNullabe = Type.GetType(typeString.Replace("?", ""));
                    if (typeString.Contains("?") && typeNonNullabe != null)
                    {
                        return typeof(Nullable<>).MakeGenericType(typeNonNullabe);
                    }
                    return t;
                }
            }
        }
