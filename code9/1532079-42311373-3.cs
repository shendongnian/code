    public static void Main()
    {
       Console.WriteLine("{0},{1},{2}", MyClass.x, MyClass.y, MyClass.z);
       MyClass mc = new MyClass(25);
       Console.WriteLine("{0},{1},{2},{3}", mc.b, mc.y, mc.z, mc.b);
       Console.ReadLine();
