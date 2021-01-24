    public static void Foo(Tuple<IEnumerable<int>, IList<int>> complex)
        {
            foreach (var item in complex.Item1)
            {
                Console.WriteLine(item.ToString());
            }
            complex.Item2.Add(9);
        }
