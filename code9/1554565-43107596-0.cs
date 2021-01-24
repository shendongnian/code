    class ConsoleApplication1
    {
        public static void Main()
        {
            List<groupOptions> g = new List<groupOptions>();
            List<dataIndicator> d = new List<dataIndicator>();
            for (int i = 0; i < 4; i++)
            {
                g.Add(new groupOptions() { groupName = i.ToString() });
                d.Add(new dataIndicator() { headerID = i, indicatorDescription = "id:" + i});
                Console.Write(g[i].groupName + ":");
                Console.WriteLine(d[i].headerID);
            }
            Console.WriteLine("enter to change");
            Console.ReadLine();
