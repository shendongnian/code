    public class MyObjectCollection<T> : List<T> where T : class
    {
        public MyObjectCollection()
        {
            using (var db = new MyContext())
            {
                foreach (T row in db.Set<T>())
                {
                    // Enumerate the data, do whatever with it...
                    this.Add(row);
                }
            }
        }
        public MyObjectCollection(Func<T, bool> MyLinqExpression)
        {
            using (var db = new MyContext())
            {
                foreach (T row in db.Set<T>().Where(MyLinqExpression))
                {
                    // Enumerate the data, do whatever with it...
                    this.Add(row);
                }
            }
        }
    }
    
