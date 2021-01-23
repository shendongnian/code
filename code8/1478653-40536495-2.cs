    public int NumConsumptionsPerClient(string client) 
    {
        var aux = listBox1.Items;
        List<int> consumptions = new List<int>();
        foreach (var i in aux)
        {
            if (i.ToString().Contains(client))
            {
                consumptions.Add(Convert.ToInt32(Regex.Match(i.ToString(), @"\d+").Value)); // only gets numbers
            }
        }
        int sumconsumptions = 0;
        foreach (int k in consumptions)
        {
            sumconsumptions = sumconsumptions + k;
        }
        return sumconsumptions;
    }
    public int NumConsumptions()
    {
        var aux = listBox1.Items;
        List<int> consumptions = new List<int>();
        foreach (var i in aux)
        {
            consumptions.Add(Convert.ToInt32(Regex.Match(i.ToString(), @"\d+").Value)); // only gets numbers
        }
        int sumconsumptions = 0;
        foreach (int k in consumptions)
        {
            sumconsumptions = sumconsumptions + k;
        }
        return sumconsumptions;
    }
     public int NumClients()
            {
                return listBox1.Items.Count;            
            }
