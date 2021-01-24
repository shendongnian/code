    public override bool Equals(object obj)
    {
        MyClass other = obj as MyClass;
        return other != null &&
               MyProperty == other.MyProperty;
    }
