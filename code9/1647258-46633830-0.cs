        private static void SaveMetalToFile(List<Ring> rings)
		{
			Dictionary<string, int> finalCollection = new Dictionary<string, int>();
			foreach(Ring item in rings.GroupBy(r => r.Metalas).ToList())
			{
				if(finalCollection.ContainsKey(item.Metalas))
				{
					finalCollection[item.Metalas]++;//incement duplicate count
				}
				else
				{
					finalCollection.Add(item.Metalas, 1);//add if not exist with count of 1
				}
			}
			using(StreamWriter writer = new StreamWriter(@"Metalai.txt"))
			{
				writer.WriteLine("|Metalai |Kiekis|");
				foreach(var item in finalCollection)
				{
					writer.WriteLine("{0};|{0}|{1}|", item.Key, item.Value);
				}
			}
		}
