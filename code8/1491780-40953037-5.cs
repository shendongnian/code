    string File1 = "AMD Intel Skylake Processors Graphics Cards Nvidia Architecture Microprocessor Skylake SandyBridge KabyLake";
    string File2 = "Graphics Nvidia";
    Dictionary<string, int> Dic = new Dictionary<string, int>();
    string[] File1Array = File1.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    Array.Sort(File1Array, (s1, s2) => s2.Length.CompareTo(s1.Length));
    foreach (string s in File1Array)
    {
        if (Dic.ContainsKey(s))
        {
            Dic[s]++;
        }
        else
        {
            Dic.Add(s, 1);
        }
    }
    string[] File2Array = File2.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    foreach (string s in File2Array)
    {
        if (Dic.ContainsKey(s))
        {
            Dic.Remove(s);
        }
    }
            
    int i = 0;
    foreach (KeyValuePair<string, int> kvp in Dic)
    {
    i++;
        Console.WriteLine(kvp.Key + " " + kvp.Value);
        if (i == 9)
        {
            break;
        }
    }
