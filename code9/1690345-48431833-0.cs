    foreach (String line in lines)
    {
        // Writes the data to the console.
        Console.WriteLine(line);
    
        String[] data = new String[5] { "monitorTime", "localTime", "actor", "action", "actor2" };
        data = line.Split(delimiter);
    
        monitorTime.Add(data[0]);
        localTime.Add(data[1]);
        actor.Add(data[2]);
        action.Add(data[3]);
        if (data.Length > 4) {
            actor2.Add(data[4]);
        }
    }
