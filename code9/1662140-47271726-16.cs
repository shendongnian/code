    public void getMssg(string ipSend, string mssg, IDictionary<string, int> table)
    {
        int result;
    
        if(!table.TryGetValue(ipSend, out result))
            result = 0;
    
        table[ipSend] = result + 1;
    }
