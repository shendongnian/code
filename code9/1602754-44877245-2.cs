    static int simpleArraySum(string input)
		{
			String[] fields = input.Split(null);
			List<int> vals = new List<int>();
			foreach (string i in fields)
			{
				var j = 0;
				if (Int32.TryParse(i, out j)) vals.Add(j);
			}
			int sum = 0;
            foreach (var item in vals)
			{
				sum += item;
			}
			return sum;
		}
