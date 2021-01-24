    public T Get<T>(T t)
    {
        if(t is TypeA) {
            TypeA a = t as TypeA;
        }
    }
