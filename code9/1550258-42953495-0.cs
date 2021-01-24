        class Model
		{
			private Dictionary<string, int> fieldsForSum = new Dictionary<string, int>();
			private int age;
			private int year;
			public int Age
			{
				get { return age; }
				set
				{
					bool isContain = fieldsForSum.ContainsKey(nameof(age));
					if (isContain)
						fieldsForSum[nameof(age)] = value;
					else
						fieldsForSum.Add(nameof(age), value);
					age = value;
				}
			}
			public int Year
			{
				get { return year; }
				set
				{
					bool isContain = fieldsForSum.ContainsKey(nameof(year));
					if (isContain)
						fieldsForSum[nameof(year)] = value;
					else
						fieldsForSum.Add(nameof(year), value);
					year = value;
				}
			}
			public int CalcIntFields()
			{
				return fieldsForSum.Values.Sum();
			}
		} 
