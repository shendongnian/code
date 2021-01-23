    public static List<Room> ReadRooms(string path)
    {
        List<Room> rooms = new List<Room>();
        string roomName=String.Empty;
        StringBuilder directionsBuilder= new StringBuilder();
        
        using (StreamReader reader = new StreamReader(path))
        { 
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line != null && line.StartsWith("[END]"))
                {
                    rooms.Add(new Room(roomName, directionsBuilder.ToString()));
                    directionsBuilder.Clear();
                }
                else if (line != null && line.StartsWith("["))
                    roomName = line.Substring(1, line.Length - 2);
                else
                    directionsBuilder.AppendLine(line);
            }
        }
        return rooms;
    }
