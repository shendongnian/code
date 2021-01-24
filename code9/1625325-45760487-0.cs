    public static void UpdateIfChanged<TClass, TField>(TClass c1, TClass c2, RefReturningFunc<TClass, TField> getter)
    {
        if (!getter(c1).Equals(getter(c2)))
        {
            getter(c1) = getter(c2);
        }
    }
