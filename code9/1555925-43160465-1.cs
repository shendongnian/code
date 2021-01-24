    Dictionary<string, int> counts = new Dictionary<string, int>();
    foreach(var i in listBox1.Items)
    {
        if (!counts.ContainsKey(i.ToString()))
            counts.Add(i.ToString(), 0);
            counts[i.ToString()]++;
        }
    }
