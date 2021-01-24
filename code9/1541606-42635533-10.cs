    public class Mgr<T>
    {
        public List<T> list;
    
        public T? GetAt1<T>(int index, T? defv = null) where T : struct
        {
            if (index < list.Count)
            {
                return list[index] as T?;
            }
            return defv;
        }
