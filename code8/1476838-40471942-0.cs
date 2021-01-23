    // your method
    public static double Inc(int i)
    {
         return i + 1;
    }
    
    // your method (overloaded)
    public static double Inc(double d)
    {
        return d + 1;
    }
    int i = Inc(3);
    double d = Inc(2.0); // You can use the same method with different parameter types
