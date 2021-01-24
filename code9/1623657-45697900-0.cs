    Dictionary<string, int> tokens = new  Dictionary<string, int>();
    int i = 0;
    while(i < gDataID.Count)
    {
       string dataToken = gDataID[i].Type.ToString();
       if(!tokens.ContainsKey(dataToken)
       {
         tokens.Add(dataToken, 0);
       }
       tokens[dataToken]++;
       
       While(i < gDataID.Count && gDataID[i].Type.ToString() == dataToken)
       {
           gDataID[i].SeqNumberOfTempCycle =  tokens[dataToken];
           i++;
       }
    }
 
