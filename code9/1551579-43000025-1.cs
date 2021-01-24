    string[] allLines = File.ReadAllLines(sVenueName + ".txt");
    List<string> EventType = allLines.Where(x => x.Contains("Event Type: Music"))
                                     .Select(x => x = "Music").ToList();
    List<int> EventAttendance = allLines.Where(x => x.Contains("People Attending:"))
                                        .Select(x => Convert.ToInt32(x.Remove(0,18))).ToList();
    int iMusicAttendance = EventAttendance.Sum();
