		static void WriteTest()
		{
			// Write sample data to CSV file
			using (CsvFileWriter writer = new CsvFileWriter(@"E:\SharedDoc1\WriteTest.csv"))
			{
				Random rnd = new Random();
				
				for (int i = 0; i < 100; i++)
				{
					CsvRow row = new CsvRow();
					for (int j = 0; j < 5; j++)
						row.Add(rnd.NextDouble().ToString("0.000000")); //round to 6 decimal digits
					writer.WriteRow(row);
				}
			}
		}
