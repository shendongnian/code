    using System;
    using System.Runtime.InteropServices;
    
    static class P
    {
        private static unsafe void Main()
        {
            MyStruct orig = new MyStruct { a = 1, b = 2, c = 3, d = 4 };
    
            byte[] raw = new byte[sizeof(MyStruct)];
            // write the empty array to prove it is empty
            Console.WriteLine(BitConverter.ToString(raw));
    
    
            // serialize
            fixed (byte* p = raw)
            {
                var typed = (MyStruct*)p;
                *typed = orig;
            }
    
            // write the serialized data
            Console.WriteLine(BitConverter.ToString(raw));
    
            // deserialize
            MyStruct clone;
            fixed (byte* p = raw)
            {
                var typed = (MyStruct*)p;
                clone = *typed;
            }
    
            Console.WriteLine($"a = {clone.a}, b = {clone.b}, c = {clone.c}, d = {clone.d}");
        }
    }
