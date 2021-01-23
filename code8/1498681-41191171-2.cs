	using (StreamWriter sw1 = File.AppendText(path1))
	{
		using (StreamWriter sw2 = File.AppendText(path2))
		{
			while (condition)
			{
				if(writeInFile1)
					sw1.WriteLine("write your line here");
				else
					sw2.WriteLine("write your line here");
			}
		}
	}
