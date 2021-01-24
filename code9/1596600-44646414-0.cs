    static void Main(string[] args)
    {
      var filename = "File_1_20170428101607";
      var date = ParseDateFromFilename(filename);
      if (date == null)
      {
        Console.WriteLine("Could not parse date");
      }
      else
      {
        Console.WriteLine("Found date: " + date.ToString());
      }
    }
    /// <summary>
    /// Takes a filename and parses the timestamp out of it
    /// If parsing is not possible it returns null
    /// else the date
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    private static DateTime? ParseDateFromFilename(string filename)
    {
      //regex is used to extract the 14 digit timestamp from filename
      var timestamp = Regex.Match(filename, @"\d{14}$");
      if (!timestamp.Success)
      {
        //if no match was found return null
        return null;
      }
      try
      {
        //try to parse the date with known timestamp and return
        return DateTime.ParseExact(timestamp.Value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
      }
      catch
      {
        //any error -> parsing was not possible -> return null
        return null;
      }
    }
