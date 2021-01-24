    List<string> allLines = File.ReadAllLines("input.txt").ToList();
    List<int> indices = Enumerable.Range(0, allLines.Count)
                                  .Where(index => allLines[index].Contains("Event Type: Music"))
                                  .Select(x => x+=3).ToList();
    List<int> EventAttendance = allLines.Where(x => indices.Contains(allLines.IndexOf(x))).Select(x => Convert.ToInt32(x.Remove(0,18))).ToList();
    int iMusicAttendance = EventAttendance.Sum();
