          string str = "Orasscleee";
			Dictionary<char,int> c=new Dictionary<char, int>();
			foreach (var cc in str)
			{
				char c1 = char.ToUpper(cc);
				try
				{
					c.Add(c1,1);
				}
				catch (Exception e)
				{
					c[c1] = c[c1] + 1;
				}
			}
			foreach (var c1 in c)
			{
				Console.WriteLine($"{c1.Key}:{c1.Value}");
			}
