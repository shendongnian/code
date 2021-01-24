    public void getMssg(string ipSend, IDictionary<string, int> table)
    {
    	int result;
    	if(!table.TryGetValue(ipSend, out result))
    		result = 0; // do something if the key is not found
    	table[ipSend] = result++;
    }
