    using (var command = new SqlCommand()) {
        command.CommandText =
            "INSERT INTO " + table.Title + " ("
          + string.Join(", ", table.Headers)
          + ") VALUES ("
          + string.Join(", ", table.Headers.Select(x => "@" + x))
          + ");";
        command.Connection = connection;
        foreach (var header in table.Headers) {
            /*
                 Add all parameters as strings. One could choose to infer the
                 data types by inspecting the first N rows or by using some sort
                 of specification to map the types from A to B.
             */
            command.Parameters.Add("@" + header, typeof(string));
        }
        foreach (var row in table.RowData) {
            for (var i = 0; i < table.Headers.Count(); i++) {
                if (!string.IsNullOrEmpty(row.ElementAt(i))) {
                    command.Parameters["@" + table.Headers.ElementAt(i)].Value = row.ElementAt(i);
                }
                else {
                    command.Parameters["@" + table.Headers.ElementAt(i)].Value = DBNull.Value;
                }
            }
            command.ExecuteNonQuery();
        }
    }
