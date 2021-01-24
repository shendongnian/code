    String[] token = value.Split(',');
    String[] datetime = token[0].Split(' ');
    String timeText = datetime[4]; // The String array contans 21:31:00
    DateTime time = Convert.ToDateTime(timeText); // Converts only the time
    Console.WriteLine(time.ToString("HH:mm:ss"));
