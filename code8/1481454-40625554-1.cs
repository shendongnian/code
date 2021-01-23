    // check for all elements of a if they exist in b and store them in c if not
    public static List<string> Excepts(List<string> a, List<string> b)
    {
        List<string> c = new List<string>();
        foreach (string s1 in a)
        {
            bool found = false;
            foreach (string s2 in b)
            {
                if (s1 == s2)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                c.Add(s1);
        }
        return c;
    }
