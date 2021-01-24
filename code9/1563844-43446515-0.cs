      // File.ReadLines is easier to read and maintain
      var items = File
       .ReadLines(@"d:\My File3.log") // single \ since we have verbatim string @ 
     //.Where(line => !string.IsNullOrWhiteSpace(line)) // if you want to remove empty lines 
       .Select(line => line.Trim().Split(' '));
      DataTable dt = new DataTable();
      foreach (var line in items) {
        // Do we want extra columns?
        while (line.Length > dt.Columns.Count)
          dt.Columns.Add(new DataColumn($"Column {dt.Columns.Count}", typeof(string)));
        dt.Rows.Add(line);
      }
      GridView1.DataSource = dt;
      GridView1.DataBind();
