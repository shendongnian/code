    static void Main(string[] args)
    {
        // here I read your posted file
        string input = System.IO.File.ReadAllText("test.txt");
        input = input.Replace('{', '<');
        input = input.Replace('}', '>');
        string pattern = "^[^<>]*" +
                  "(" +
                  "((?'Open'<)[^<>]*)+" +
                  "((?'Close-Open'>)[^<>]*)+" +
                  ")*" +
                  "(?(Open)(?!))$";
        //string input = "<abc><mno<xyz>>";
        Match m = Regex.Match(input, pattern);
        if (m.Success == true)
        {
            Console.WriteLine("Input: \"{0}\" \nMatch: \"{1}\"", input, m);
            int grpCtr = 0;
            foreach (Group grp in m.Groups)
            {
                Console.WriteLine("   Group {0}: {1}", grpCtr, grp.Value);
                grpCtr++;
                int capCtr = 0;
                foreach (Capture cap in grp.Captures)
                {
                    Console.WriteLine("      Capture {0}: {1}", capCtr, cap.Value);
                    capCtr++;
                }
            }
        }
        else
        {
            Console.WriteLine("Match failed.");
        }   
        Console.ReadKey();
    }
