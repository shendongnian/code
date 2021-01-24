 	if (!File.Exists(sVenueName.ToString() + ".txt"))
        return;
    List<String> EventType = new List<string>();      //Store found event types
    List<int> EventAttendance = new List<int>();      //Store Event Attendance
    using (StreamReader file = new StreamReader(sVenueName + ".txt"))       //Using StreamReader
    {
        while (!file.EndOfStream)
        {
            var line = file.ReadLine(); //Declare String to store line
            //Get All Music Event to Array
            if (line.Contains("Event Type: Music"))
            {
                EventType.Add("Music");        //[0] = Music
            }
            //Get All attendances to Array
            if (line.Contains("People Attending:"))
            {
                line = line.Remove(0, 18);
                EventAttendance.Add(Convert.ToInt32(line));   //[0] = 10
            }
        }
    }
    //for each array index and if array index contains music, add this to total amount of music events        
    iMusicAttendance = EventAttendance.Sum();
