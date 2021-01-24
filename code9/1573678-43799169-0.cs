    static string[] showPath(List<PathFinderNode> mPath)
    {
        List<string> paths = new List<string>();
        string disP = string.Empty;
        MessageBox.Show("show path reached"); //method check
        try
        {
            foreach (PathFinderNode node in mPath)
            {
                if ((node.X - node.PX) > 0) { disP = "Right"; }
                if ((node.X - node.PX) < 0) { disP = "Left"; }
                if ((node.Y - node.PY) > 0) { disP = "UP"; }
                if ((node.Y - node.PY) < 0) { disP = "Down"; }
                paths.Add(disP);
            }
        }
        catch (FormatException p)
        {
            Console.WriteLine(p.Message);
        }
        return paths.ToArray();
    }
