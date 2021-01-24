    public void getMssg(string ipSend, string mssg, Dictionary<string,int> table)
    {
        if (table.ContainsKey(ipSend))
            table[ipSend] += 1;
        else
            table.Add(ipSend, 1);
    }
