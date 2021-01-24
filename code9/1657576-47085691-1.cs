    public void Foo()
    {
        string dataType = "MyClass"; // Pretend this string was specified by the user
        Type t = Type.GetType(dataType);
        Type u = Type.GetType(dataType + "Comparer"); // Implements IEqualityComparer<MyClass>
        MethodInfo method = this.GetType().GetMethod("GetUniqueItemCount", BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo generic = method.MakeGenericMethod(t, u);
        int count = (int)generic.Invoke(this, new object[] { "some data blah blah" });
    }
    
    private void GetUniqueItemCount<T, U>(string data) where T : class
                                                       where U : IEqualityComparer<T>, new()
    {
        MyDataContext context = new MyDataContext();
        var list = (
            from v in context.GetTable<SomeTable>()
            select v.SomeColumn).ToList()
                .Select(cellValue => Activator.CreateInstance(typeof(T), new object[] { cellValue }) as T)
                .ToList();
        return list.Distinct(new U()).Count();
    }
