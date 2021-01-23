	var lines = str.Split('\n');
	
	var q = new Queue<string>();
	
	foreach (var l in lines)
	{
		q.Enqueue(l);
		if (l.Contains("Process Completed"))   // you could use a regex here if you want more
                                               // complex matching
		{
			string output;
			while (q.Count > 0)
			{
                // your queue here would contain exactly one entry
				output = q.Dequeue();
				Console.WriteLine(output);
			}
		}
	}
