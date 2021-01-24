    Regex regex = new Regex("^([^@]+)@([^;]+);([^:]+):(.+)$", RegexOptions.Compiled);
    string[] lines = File.ReadAllLines("PathToTheList");
    foreach (string line in lines)
    {
        Match match = regex.Match(line);
        if (match.Success)
        {
            GroupCollection groups = match.Groups;
            // group[0].ToString() == line
            string ip = groups[1].ToString();
            string domain = groups[2].ToString();
            string username = groups[3].ToString();
            string password = groups[4].ToString();
        }
    }
