    StringBuilder builder = new StringBuilder();
    using (StreamReader reader = new StreamReader(@"c:\email.txt"))
    {
    	while (!reader.EndOfStream)
    	{
            var line = reader.ReadLine();
            if (line.EndsWith(myWord))
            {
    		    builder.AppendLine(line);
            }
    	}
    }
    outputEmails.Text = builder.ToString();
