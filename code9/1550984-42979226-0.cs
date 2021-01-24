        string line = RetrieveEvents.ReadLine();                                        
        while (RetrieveEvents.Peek() != -1)
        {
            if (line.Contains("Event Name:")) //When this line is found,
            {
                EventString = line.Remove(0, 12);                         
                lstDisplayActivities.Items.Add(line);
                
            }
            else if(line.Contains("Event Type:"))
            {
                EventType = line.Remove(0, 12);
                lstDisplayActivities.Items.Add(line);
            }
            else if(line.Contains("People Attending:"))
            {
                EventPeopleAttending = line.Remove(0, 18);
                lstDisplayActivities.Items.Add(line);
            }
            // This reads the next line.....
            line = RetrieveEvents.ReadLine()
        }
    }
