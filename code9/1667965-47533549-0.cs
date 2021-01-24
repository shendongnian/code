    foreach (string row in csvData.Split('\n'))
    {
      if (!string.IsNullOrEmpty(row))
      {
        string jsonString = new 
    System.Web.Script.Serialization.JavaScriptSerializer().Serialize(row); //Per row
        dt.Rows.Add();
        int i = 0;
        //Execute a loop over the columns.  
        foreach (string cell in row.Split(','))
        {
          dt.Rows[dt.Rows.Count - 1][i] = cell;
          Console.WriteLine(dt.Rows[dt.Rows.Count - 1][i]);
          i++;
        }
      }
      var telemetryDataPoint = row;
    }
