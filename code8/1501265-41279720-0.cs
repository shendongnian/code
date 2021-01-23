        public static class TypeExtensions 
        {
                /// <summary>
                /// Gets the inner type of the given type, if it is an Array or has generic arguments. 
                /// Otherwise NULL.
                /// </summary>
                public static Type GetInnerListType(this Type source)
                {
                    Type innerType = null;
        
                    if (source.IsArray)
                    {
                        innerType = source.GetElementType();
                    }
                    else if (source.GetGenericArguments().Any())
                    {
                        innerType = source.GetGenericArguments()[0];
                    }
        
                    return innerType;
                }
         }
