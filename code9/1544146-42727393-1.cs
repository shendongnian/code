    while ((line = file.ReadLine()) != null)
    {
        string[] parts = new string[4];
        int n = -1;
        for (int idx = 0; idx < 3; idx++)
        {
            n = line.LastIndexOf(' ');
            parts[3-idx] = line.Substring(n + 1);
            line = line.Substring(0, n).TrimEnd();
        }
	
        parts[0] = line; // filename
    }
