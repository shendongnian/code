    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            string filename = @"c:\temp\baby.txt";
            string year = "1997";
			string gender = "F";
			string name = "Margaret";
            string line = "";
            try
            {
                using (StreamReader fin = new StreamReader(filename))
                {
                    while((line = fin.ReadLine()) != null)
                    {
                        string[] parsed = line.Split(',');
                        if (parsed[1] == gender)
                        {
                                names.Add(parsed[0]);
                        }
                    }
                }
				
				bool foundName = false;
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i] == (name)) 
                    {
                        Console.WriteLine(name + " is ranked #" + i-1 + " in year " + year);
						foundName = true;
						break;
                    }
                }
				
				if (!foundName)
				{
                     Console.WriteLine("The name " + name
                            + " is not ranked in year " + year);
                }
				
            }
            catch(Exception e  )
            {
                Console.WriteLine("The file at {0} could not be read."+ e,  filename);
            }
            for(int c = 0; c < names.Count; c++)
            {
                Console.WriteLine((c + 1) + ". " + names[c]);
            }
            Console.ReadKey();
        }
    }
