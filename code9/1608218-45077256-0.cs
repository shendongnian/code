        static void Main(string[] args)
        {
            Tuple<int, double>[] obs1 = new Tuple<int, double>[] { new Tuple<int, double>(1, 1.2), new Tuple<int, double>(2, 1.5), new Tuple<int, double>(3, 2.2) };
            Tuple<int, double>[] obs2 = new Tuple<int, double>[] { new Tuple<int, double>(1, 2.1), new Tuple<int, double>(2, 5.1), new Tuple<int, double>(4, 2.2) }; ;
            Tuple<int, double>[] obs3 = new Tuple<int, double>[obs1.Count()];
            for (int i = 0; i < obs1.Count(); i++)
            {
                for (int j = 0; j < obs2.Count(); j++)
                {
                    if (obs1[i].Item1 == obs2[j].Item1)
                    {
                        obs3[i] = new Tuple<int, double>(obs1[i].Item1, obs1[i].Item2 + obs2[j].Item2);
                        break;
                    }
                }
            }
            foreach (var item in obs3)
            {
                Console.WriteLine(item?.Item1 + "\t" + item?.Item2);
            }
            Console.ReadKey();
        }
