    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> items = new SortedSet<string>();
            SortedSet<string> set = new SortedSet<string>();
            SortedSet<string> set2 = new SortedSet<string>();
            set.Add("a");
            set.Add("b");
            set.Add("d");
            set.Add("c");
            set2.Add("e");
            set2.Add("d");
            set2.Add("c");
            foreach (string item in set)
            {
                items.Add(item);
            }
            foreach (string item in set2)
            {
                items.Add(item);
            }
            DisplayItem(items);
        }
        public static void DisplaySet(SortedSet<string> set)
        {
            string set1 = string.Join(",", set);
            Console.WriteLine(set1);
            Console.ReadLine();
        }
        public static void DisplayItem(SortedSet<string> items)
        {
            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
