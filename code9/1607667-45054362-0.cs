    public class ConvertTypeClass<T1,T2>
        {
            public T1 ConvertMethod(T2 val)
            {
                return (T1) (Convert.ChangeType(val, typeof(T1)));
            }
        } 
