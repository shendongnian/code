    public IQueryable<TSource> GetTable<TSource>()
         where TSource : IPersonData
    {
        return this.GetTable(typeof(TSource))
    }
    public IQueryable<TSource> GetTable(System.Type type)
    {
         if (type == typeof(Teacher)) return this.Teachers;
         else if (type == typeof(Student)) return this.Students;
         ...
         // TODO: improve this code by using a switch statement
         // TODO: search stackoverflow how to do this for a type
    }
