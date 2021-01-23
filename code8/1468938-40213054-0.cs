    string name = String.Empty;
	string last_job_description = String.Empty;
	int[] job_codes = null;
	string job_address = String.Empty;
	string comments = String.Empty;
	int numberOfPropertiesRead = 0;
	var lines = File.ReadAllLines("C:/yourfile.txt");
	for (int i = 0; i < lines.Count(); i++)
	{
		var line = lines[i];
		bool newProp = line.StartsWith("*");
		bool endOfProp = line.EndsWith("*");
		if (newProp)
		{
			numberOfPropertiesRead++;
			line = line.Substring(1);
		}
		if (endOfProp)
			line = line.Substring(0, line.Length - 1);
		switch (numberOfPropertiesRead)
		{
			case 1: name += line; break;
			case 2: last_job_description += line; break;
			case 3:
				job_codes = line.Split(' ').Select(el => Int32.Parse(el)).ToArray();
				break;
			case 4: job_address += line; break;
			case 5: comments += line; break;
			default:
				throw new ArgumentException("Wow, that's too many properties dude.");
		}
	}
	Console.WriteLine("name: " + name);
	Console.WriteLine("last_job_description: " + last_job_description);
	foreach (int job_code in job_codes)
		Console.Write(job_code + " ");
	Console.WriteLine();
	Console.WriteLine("job_address: " + job_address);
	Console.WriteLine("comments: " + comments);
	Console.ReadLine();
