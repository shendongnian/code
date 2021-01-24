    public class ValMgr<T> where T : struct
    {
        public List<T> list;
        public T? GetAt(int index, T? defv = null)
        {
            if (index < list.Count)
            {
                return list[index] as T?;
            }
            return defv;
        }
    }
