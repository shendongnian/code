    public static double SeName0(MyType new_name)
    {
        new_name = new MyType(); // only new_name reference to a new object
    }
    public static double SeName1(ref MyType new_name)
    {
        new_name = new MyType(); // both name and ref new_name reference to a new object
    }
    public static void Main()
    {
       MyType name;
       SeName0(name); // Do not touch name variable in this local scope
       SeName1(name); // Change name reference to new object
    }
