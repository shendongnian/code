	string s = "12.4567 0.1234\n"; // just an example
	decimal d = 0;
	foreach (char c in s)
	{
		if (char.IsDigit(c))
		{
			d *= 10;
			d += c - '0';
		}
		else if (c == ' ' || c == '\n')
		{
			d /= 60000; // divide by 10000 to get 4dps; divide by 6 here too
			Console.Write(d.ToString("F4"));
			Console.Write(c);
			d = 0;
		}
        else {
            // no special processing needed as long as input file always has 4dp
            Debug.Assert(c == '.');
        }
	}
