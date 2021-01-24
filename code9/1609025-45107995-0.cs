    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Spooky());
            Console.WriteLine("");
            Console.Write("Press Enter to Quit...");
            Console.ReadKey();
        }
        static public string Spooky()
        {
            string story = "They all agreed that it was a huge {0}, {1}, {2}, and {3}."
                + " I have cross-examined these men, one of them a hard-headed "
                + "{4}, one a {5}, and one a moorland {6}"
                + ", who all tell the same story of this "
                + "{7} {8}, exactly corresponding to the {9} of the legend.";
            string[] prompts = {
                "noun", "adjective", "adjective", "adjective",
                "occupation", "occupation", "occupation",
                "adjective", "noun", "noun" };
            return MadLib(story, prompts);
        }
        static string MadLib(string story, string[] prompts)
        {
            List<string> answers = new List<string>();
            foreach (string prompt in prompts)
            {
                answers.Add(Input(prompt));
            }
            return String.Format(story, answers.ToArray());
        }
        static string Input(string part)
        {
            Console.Write("Please enter a {0}: ", part);
            return Console.ReadLine();
        }
    }
