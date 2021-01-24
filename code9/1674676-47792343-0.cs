    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> names = new Dictionary<string, int>();
			string gender = "F";
			string name = "Margaret";
			int year = 1997;
            
            var lines = File.ReadAllLines(@"c:\temp\baby.txt");
			foreach (var line in lines)
            {
                string[] parsed = line.Split(',');
                if (parsed[1] == gender)
                {
                    names.Add(parsed[0], int.Parse(parsed[2]));
                }
            }
			
			if (names.ContainsKey(name))
			{
				Console.WriteLine("{0} is ranked #{1} in year {2}", name, names[name], year);
			}
			else
			{
				 Console.WriteLine("The name {0} is not ranked in year {1}", name, year);
			}			
        }
    }
