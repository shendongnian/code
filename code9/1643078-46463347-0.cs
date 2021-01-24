	public List<double> GetPowersOf2(int input)
    {
        var returnList = new List<double>();
    
        for (int i = 0; i < input + 1; i++)
        {
            returnList.Add(Math.Pow(2, i));
        }
        return returnList;
     }
	
        public static void Main(String[] args)
        {
            Program p = new Program();
            p.GetPowersOf2(2).ForEach(Console.WriteLine);
        }
    }
