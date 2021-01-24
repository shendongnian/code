    public class Data
    {
        public static void Update<T>(Func<T, bool> where, Action<T> change)
        {
            IEnumerable<T> items = ((IEnumerable<T>)myDataContext.GetTable(typeof(T))).Where(where);
            
            foreach (T item in items)
            {
                change(item);
            }
            myDataContext.SubmitChanges();
        }
    }
