    static int simpleArraySum(string input)
		{
			String[] fields = input.Split(null);
            int[] vals = new int[fields.Length];
            for (int i = 0; i < fields.Length; i++)
			{
				var j = 0;
                if (Int32.TryParse(fields[i], out j)) vals[i] = j;
			}
			int sum = 0;
            foreach (var item in vals)
			{
				sum += item;
			}
			return sum;
		}
