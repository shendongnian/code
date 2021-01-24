    private void WriteToFile(List<Event> allEvents, string filepath) {
      try {
        using (StreamWriter sw = new StreamWriter(filepath)) {
          foreach (Event curEvent in allEvents) {
             sw.WriteLine(curEvent.EventName + "," + curEvent.EventDateTime.ToString());
          }
        }
      }
      catch (Exception e) {
        Console.WriteLine("Write Error: " + e.Message);
        Console.ReadKey();
      }
    }
