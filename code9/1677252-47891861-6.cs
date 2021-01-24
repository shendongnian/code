    public ColumnWriter this[object o] => WriteLine(o);
    public ColumnWriter this[object o1, object o2] => WriteLine(o1, o2);
    public ColumnWriter this[object o1, object o2, object o3] => WriteLine(o1, o2, o3);
    //  ...moar overloards
    //  In C# x[0]; is an expression, not a statement. 
    //  x[0].End(); is a statement. Horrible, most horrible. 
    //  Maybe I should name it FireMe() instead of End()
    public void End() { }
