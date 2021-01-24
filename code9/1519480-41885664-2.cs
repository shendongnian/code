    public MyObjectCollection(Func<T, bool> MyLinqExpression)
    {
        using (var db = new MyContext())
        {
            foreach (T row in db.Set<T>().Where(MyLinqExpression))
            {
                // Enumerate the data, do whatever with it...
                myInternalCollection.Add(row);
            }
        }
    }
