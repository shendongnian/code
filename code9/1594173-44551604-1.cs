    static void Main(string[] args)
            {
                MyClass a = new MyClass();
                MyClass b = new MyClass();
                Console.WriteLine(MyClass.instanceCount);
                b.Dispose();
                Console.WriteLine(MyClass.instanceCount);
                Console.ReadLine();
            }
