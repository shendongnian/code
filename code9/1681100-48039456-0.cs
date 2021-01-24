    static void Main(string[] args)
    {
    			ConsoleColor[] colors =
    	   {
    			ConsoleColor.Blue,
    			ConsoleColor.Red,
    			ConsoleColor.Black,
    			ConsoleColor.Green
    		};
    
    			String[] names =
    			{
    			"BLUE",
    			"RED",
    			"BLACK",
    			"GREEN"
    		};
    
    			Random r = new Random();
    			int i = 0;
    			while(i==0)
    				i=r.Next() % (names.Length-1);
    			List<int> rndList = Enumerable.Range(0,names.Length).OrderBy(x => r.Next()).ToList();
    			Console.BackgroundColor = ConsoleColor.White;
    			foreach(int j in rndList)
    			{
    				int k = (j+i) % (colors.Length);
    				Console.ForegroundColor = colors[k];
    				Console.Write(names[j] + " ");
    			}
    }
