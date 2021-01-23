       class Program
        {
            static void Main(string[] args)
            {
                myMethod<EnumA>("deneme", EnumA.name);
            }
            public enum EnumA
            {
                name = 1,
                surname = 2
            }
            public enum EnumB
            {
                name = 50,
                surname = 60
            }
            public static void myMethod<T>(string u, T e)
                where T : struct,IConvertible
            {
                if (typeof(T) == typeof(EnumA))
                {
                    Console.WriteLine("EnumA");
                }
               else if (typeof(T) == typeof(EnumB))
                {
                    Console.WriteLine("EnumB");
                }
                Console.ReadLine();
            }
        }
