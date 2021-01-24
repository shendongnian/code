    // dt - your DataTable with DataRows, where dataRow[0] - is int id, and dataRow[1] - is DateTime.
    dt.Rows.AsParallel()
                    .ConvertAll(dr => new
                    {
                        id = int.Parse((dr as DataRow)[0].ToString()),
                        dateTime = new TimeSpan(DateTime.Parse((dr as DataRow)[1].ToString()).Ticks),
                    })
                    .GroupBy(objIdDate => objIdDate.dateTime.TotalDays);
