    DataTable dataTable = this.ChimneyTable; 
    // changes start here
    this.oChimneys = new Chimney[dataTable.Rows.Count];
    int num = 0;
    foreach(DataRow dataRow in dataTable.Rows)
    {
        // the part in the loop while (enumerator.MoveNext())
        num++; // was the last line... for orientation
    }
    // end of changes
    IL_247: // superflous, just for your orientation
