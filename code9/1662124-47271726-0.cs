    public void getMssg(string ipSend, string mssg, Hashtable table)
    {
        if (table.Contains(ipSend))
        {
            int value = (int)table[ipSend];
            table[ipSend] = value + 1;
        }
    }
