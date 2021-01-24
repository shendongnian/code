    public Dictionary<string,string> ToDictionary(string[] t)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (string s in t)
        {
            string[] reg = s.Split('=');
            int i = 1;
            while (dict.ContainsKey(reg[0]))
            {
                if (!reg[0].Contains('['))
                    reg[0] = reg[0] + "[" + i.ToString() + "]";
                else
                    reg[0] = reg[0].Replace((i - 1).ToString(), i.ToString());
                i++;
            }
                
            dict.Add(reg[0], reg[1]);
        }
        return dict;
    }
