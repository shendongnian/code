        var aux =listBox1.Items;
        int sumclients = aux.Count;
        List<int> consumptions = new List<int>();
        foreach(var i in aux)
        {
            consumptions.Add(Convert.ToInt32(Regex.Match(i.ToString(), @"\d+").Value)); // only gets numbers
        }
        int sumconsumptions = 0;
        foreach(int k in consumptions)
        {
            sumconsumptions = sumconsumptions + k;
        }
        MessageBox.Show("People: " + sumclients + " Sum of consumptions: " + sumconsumptions);
