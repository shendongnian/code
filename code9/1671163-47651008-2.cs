    var newSort = from row in dtFinal.AsEnumerable()
      let xRow = new { Row = row, valueAmount = decimal.Parse(row.Field<string>("ValueAmount")) }
      group xRow by new
      {
         Substation = row.Field<string>("Substation"),
         ColumnTitle = row.Field<string>("ColumnTitle")
      } into grp
      let maxRow = grp.OrderByDescending(x => x.valueAmount).First()
      select new
      {
         ptime = maxRow.Row.Field<string>("ptime"),
         grp.Key.Substation,
         grp.Key.ColumnTitle,
         ValueAmount = maxRow.valueAmount
      };
