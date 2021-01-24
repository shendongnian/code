    private DataTable CalculateWorkingHours(DataTable excelSheetDataTable)
    {
        //Group all the data rows by user name and respective date
        var dd = excelSheetDataTable.Rows.Cast<DataRow>().GroupBy(c => new { name = c[0].ToString(), date = DateTime.Parse(c[1].ToString()).Date });
        //Create result table and some column in the table
        DataTable result = new DataTable();
        result.Columns.Add("user");
        result.Columns.Add("work hour");
        result.Columns.Add("date");
        // loop all user and their respective date in - out
        foreach (var item in dd)
        {
            // for each user each day order the record by date time.
            var sortByDateTime = item.ToList().OrderBy(c => DateTime.Parse(c[1].ToString()));
            //first in record for the day
            var fIn = sortByDateTime.FirstOrDefault(c => string.Equals(c[2].ToString(), "IN", StringComparison.InvariantCultureIgnoreCase));
            // if first in record for the day exist go further
            if (fIn != null)
            {
               // last out record for the day
                var lOut = sortByDateTime.LastOrDefault(c =>
                {
                    return
                        string.Equals(c[2].ToString(), "OUT", StringComparison.InvariantCultureIgnoreCase)
                        ||
                        string.Equals(c[2].ToString(), "Exit", StringComparison.InvariantCultureIgnoreCase);
                });
                // if last out record for the day exist too..
                if (lOut != null)
                {
                   // find the first enter date time, last exist date time.
                    var fTime = DateTime.Parse(fIn[1].ToString());
                    var lTime = DateTime.Parse(lOut[1].ToString());
                    //add the new row to the result table,
                    var r = result.NewRow();
                    r[0] = item.Key.name;
                    r[1] = (lTime - fTime).ToString(@"hh\:mm\:ss");
                    r[2] = item.Key.date;
                    result.Rows.Add(r);
                }
            }
        }
        return result;
    }
