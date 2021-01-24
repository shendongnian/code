    while ((line = file.ReadLine()) != null)
    {
        string[] parts = new string[4];
        int n = -1;
        for (int idx = 0; idx < 3; idx++)
        {
            n = line.LastIndexOf(' ');
            if (n == -1 || n == 0) break;
            string part = line.Substring(n + 1);
            if (part.IndexOf(':') > 0) parts[2] = part;
            else if (part.Length == 8) parts[1] = part;
            else parts[3] = part; // assuming you don't have 8-digit filesizes
            line = line.Substring(0, n).TrimEnd();
        }
	
        parts[0] = line.TrimEnd(); // filename
    }
