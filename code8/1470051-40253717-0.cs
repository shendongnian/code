    class Program
    {
        static void Main(string[] args)
        {
            string cColl = System.IO.File.ReadAllText(@"C:\some.txt");
            //string cColl = "This is similar, similar, similar, similar, similar, similar";
            Console.WriteLine(cColl);
            string cCriteria = @"\b" + "similar" + @"\b";
            Regex oRegex = new Regex(cCriteria, RegexOptions.IgnoreCase);
            int count = oRegex.Matches(cColl).Count;
            Console.WriteLine(count.ToString());
            Console.ReadLine();
        }
    }
}
