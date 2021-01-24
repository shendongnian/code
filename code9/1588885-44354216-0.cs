    class Bob
    {
        public int index;
        public int countNr;
        public string descA;
        public string descB;
        public Bob(int index, int countNr, string descA, string descB)
        {
            this.index = index;
            this.countNr = countNr;
            this.descA = descA;
            this.descB = descB;
        }
        public override string ToString()
        {
            return $"{index} - {countNr} - {descA} - {descB}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Bob>
            {
                new Bob(1, 3, "a1", "b1"),
                new Bob(2, 2, "a2", "b2"),
                new Bob(3, 2, "a3", "b3"),
                new Bob(4, 1, "a4", "b4"),
                new Bob(5, 1, "a5", "b5"),
                new Bob(6, 1, "a6", "b6"),
                new Bob(7, 1, "a7", "b7")
            };
            var newList = list.OrderBy(z => z.countNr).ThenByDescending(y => y.index).ToList();
            newList.ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }
