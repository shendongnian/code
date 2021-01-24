    private static void Main()
    		{
    			List<Program.Printer> printers = new List<Program.Printer>();
    			int i;
    			int j;
    			for (i = 0; i < 10; i = j + 1)
    			{
    				printers.Add(delegate
    				{
    					int d = i;
    					Console.WriteLine(d);
    				});
    				j = i;
    			}
    			foreach (Program.Printer printer in printers)
    			{
    				printer();
    			}
    			Console.ReadLine();
    		}
