    static void Main(string[] args)
    {
        string txt = "---TIMESTAMP Tue, 24 Oct 2017 02:11:56 -0400 [1508825516987]---";
    
        Regex regex = new Regex(@"\[(.*?)\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        Match match = regex.Match(txt);
        if (match.Success)
        {
            for (int i = 1; i < match.Groups.Count; i++)
            {
                String extract = match.Groups[i].ToString();
                Console.Write(extract.ToString());
            }
        }
        Console.ReadLine();
    }
