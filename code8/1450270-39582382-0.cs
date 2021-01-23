    List<MotorModel> motorModels;   // filled in previously
    // build result structure in this dictionary:
    Dictionary<DateTime, List<MotorDataModel>> table = new Dictionary<DateTime, List<MotorDataModel>>();
    // iterate through all motors and their data, and fill in the table
    foreach(MotorModel m in motorModels)
    {
        foreach(MotorDataModel md in m.MotorData)
        {
            DateTime ts = md.timestamp;
            // if this is the first occurance of the timestamp, create new 'row'
            if (!table.ContainsKey(ts)) table[ts] = new List<MotorDataModel>();
            // add the data to the 'row' of this timestamp
            table[ts].Add(md);
        }
    }
    
    // output the table
    foreach(DateTime ts in table.Keys)
    {
        ...
        foreach(MotorDataModel md in table[ts])
        {
            ...
        }
    }
