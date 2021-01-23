    public static bool Is<T>(this T variable,Type type)
        {
            if (var != null)
            {
                Type currentType = variable.GetType();
                type = Nullable.GetUnderlyingType(type) ?? type;
                while (currentType != typeof(object))
                {
                    if (currentType == type)
                    {
                        return true;
                    }
                    currentType = currentType.BaseType;
                }
            }                  
            return false;
        }
