            GenericClass<T> list = new GenericClass<T>();
            for(int x = 0; x <10; x++)
            {
                list.AddHead(conv(x));
            }
            System.Console.WriteLine("\nPrinting generic class using ints.");
            foreach (T i in list)
            {
                System.Console.Write(inv(i) + ", ");
            }
