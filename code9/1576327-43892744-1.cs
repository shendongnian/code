    public T Get<T>(T t)
    {
        if(t is TypeA) {
            TypeA a = (TypeA) Convert.ChangeType(t, typeof(TypeA));
        }
    }
