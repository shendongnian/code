    public void loadPatterns()
    {
        string[] files = Directory.GetFiles("patterns/");
        Level pattern = new Level();
        List<char> row = new List<char>();
        List<List<char>> grid = new List<List<char>>();
    
        for(int i = 0; i < files.Length; i++)
        {
            var lines = File.ReadLines(files[i]);
            foreach(string line in lines)
            {
                foreach(char c in line)
                {
                    row.Add(c);
                }
                grid.Add(row);
                row = new List<char>(); // <-
            }
            pattern.grid = grid;
            patterns.Add(pattern);
            grid.Clear();
        }
    }
