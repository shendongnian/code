            var oi = (object)17;
            MutateValueType<int>(oi, 43);
            Console.WriteLine(oi); // 43
            var od = (object)17.7d;
            MutateValueType<double>(od, 42.3);
            Console.WriteLine(od); // 42.3
