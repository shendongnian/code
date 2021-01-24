    public static bool Compare ( this T obj, T comparer )
    {
        bool isOkay = true;
        foreach(var field in typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        {
            if (!isOkay) break;
            object value = field.GetValue(obj);
            object comparerValue = field.GetValue(comparer);
            Type type = field.FieldType;
            if(Type.GetTypeCode(type) != TypeCode.Object)
            {
                if(type == typeof(IList))
                {
                    for(int i = 0; i < ((IList)value).Count; i++)
                    {
                        isOkay = isOkay &&(bool)_GenericCompare.MakeGenericMethod(((IList)value)[i].GetType()).Invoke(((IList)value)[i], ((IList)comparerValue)[i]);
                    }
                }
            }
            else
            {
                isOkay = isOkay && value.Equals(comparerValue);
            }
        }
        return isOkay;
    }
    // _GenericVompare is :
    typeof(MeTypeThatHasCompareMethod).GetMethod("Compare", BindingFlags.Static | BindingFlags.Public);
