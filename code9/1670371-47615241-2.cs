	static void GetRecords(Record[] patient_rec)
	{
		for (int i = 0; i < patient_rec.Length; i++)
		{
			Console.WriteLine("Record {0} of {1} entry", i + 1, patient_rec.Length);
			patient_rec[i] = new Record()
			{
				_Age = AskInteger("Enter your age: "),
				_Name = AskString("Enter your name: "),
				_Gender = AskGender("Enter your gender (female or male): "),
			};
			string ask = "";
			while (string.IsNullOrEmpty(ask) || (ask.ToLower()[0] != 'y' && ask.ToLower()[0] != 'n'))
			{
				Console.WriteLine("Continue? yes or no (then hit enter)");
				ask = Console.ReadLine();
			}
			if (ask.ToLower()[0] == 'y')
			{
				continue;
			}
			break;
		}
		Console.WriteLine("Thank you. Input completed.");
	}
