    public void RecordKeeper(object sender, ElapsedEventArgs e)
    {
        for (int x = 0; x < record_list.Count; x++)
        {
            record_list[x].TTL = record_list[x].TTL.Add(TimeSpan.FromSeconds(1));
            Console.WriteLine(record_list[x].TTL.ToString());
            if (record_list[x].TTL > TimeSpan.FromSeconds(70))
            {
                RemoveRecord(x);
            }
        }                          
    }
