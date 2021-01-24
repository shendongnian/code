    while ((line = reader.ReadLine()) != null)
    {
      if (line.Contains("Specific Lat/Long Value"))
        {
            line.Replace("Specific Lat/Long Value", "New Value");
        }
    }
