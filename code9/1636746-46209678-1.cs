    static void Main(string[] args)
		{
			for (int i = 0; i < 11; i++)
			{
				PrintRow(i);
			}
            Console.ReadLine();
		}
		private static void PrintRow(int i)
		{
			var args = new List<string>();
			if (i == 0)
			{
				for (int k = 0; k < 11; k++)
				{
					if (k == 0)
					{
						args.Add("*");
					}
					else
					{
						if (k == 1)
						{
							args.Add("|");
						}
						else
						{
							args.Add((k - 1).ToString());
						}
					}
				}	
				
			}
			else
			{
				if (i == 1)
				{
					for (int k = 0; k < 11; k++)
					{
						args.Add("-----");
					}
				}
				else
				{
					for (int k = 0; k < 11; k++)
					{
						if (k == 0)
						{
							args.Add((i - 1).ToString());
						}
						else
						{
							if (k == 1)
							{
								args.Add("|");
							}
							else
							{
								args.Add(((i - 1) * (k -1)).ToString());
							}
						}
					}
				}
			}
			
			Console.WriteLine(string.Format("{0,5}{1,5}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,5}", args.ToArray()));
		}
