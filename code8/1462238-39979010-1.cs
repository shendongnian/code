    public static List<Room> ReadRooms(string path)
    {
        List<Room> rooms = new List<Room>();
        bool inRoom = false;
        StringBuilder directions = new StringBuilder();
        string name = null;
        foreach (var line in File.ReadLines(path))
        {
            if (inRoom)
            {
                if(line == "[END]")
                {
                    rooms.Add(new Room(name, directions.ToString()));
                    inRoom = false;
                    directions.Clear();
                }
                else if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    // Found a start before the end, condiser throwing an 
                    // exception, ignoring, or keep it as part of the directions.
                }
                else
                {
                    directions.AppendLine(line);
                }
            }
            else
            { 
                if(line == "[END]")
                {
                    // Found an end before a start either throw an exception or
                    // just ignore this.
                }
                else if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    inRoom = true;
                    name = line.Trim('[', ']');
                }
                else
                {
                    // Consider throwing an exception here or just ignoring lines 
                    // between [END] and the next room.
                }
            }
        }
        if (inRoom)
        {
            // Determine what to do if you had a room start, but no [END]
        }
        return rooms;
    }
