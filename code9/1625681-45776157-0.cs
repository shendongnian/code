    using System;
    
    public class Test
    {
    	static void Main()
    	{
            Foo(10, 20, 0x80, 0x8d, 0xff);
    	}
    
        static void Foo(int x, int y, params byte[] bytes)
        {
            Console.WriteLine($"x: {x}");
            Console.WriteLine($"y: {y}");
            Console.WriteLine($"bytes: {BitConverter.ToString(bytes)}");
        }
    }
