    public static void Main()
    {
       Console.WriteLine("{0},{1},{2}", MyClass.x, MyClass.y, MyClass.z);
       MyClass mc = new MyClass(25);
       Console.WriteLine("{0},{1},{2}", MyClass.x, MyClass.y, MyClass.z);
       Console.WriteLine("{0}", mc.b);
       Console.ReadLine();
    }
