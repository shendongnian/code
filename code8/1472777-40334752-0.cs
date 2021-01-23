    static public int input(){
           Console.WriteLine("Enter The Number Of Student You Want to get Record");
            string input = Console.ReadLine();
            if (Regex.IsMatch(input, @"\d+"))
            {
                return int.Parse(Regex.Match(input, @"\d+").Value);
            }
            else
            {
                return input();
            }
    }
