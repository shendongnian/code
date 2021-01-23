    using (var command = new SqlCommand()) {
        command.CommandText =
            "INSERT INTO " + table.Title + " ("
          + string.Join(", ", table.Headers)
          + ") VALUES ("
          + string.Join(", ", table.Headers.Select(x => "@" + x))
          + ");";
        command.Connection = connection;
        foreach (var header in table.Headers) {
            command.Parameters.Add("@" + header);
        }
        foreach (var row in table.RowData) {
            for (var i = 0; i < table.Headers.Count(); i++) {
                if (!string.IsNullOrEmpty(row.ElementAt(i))) {
                    command.Parameters["@" + table.Headers.ElementAt(i)] = row.ElementAt(i);
                }
                else {
                    command.Parameters["@" + table.Headers.ElementAt(i)] = DBNull.Value;
                }
            }
            command.ExecuteNonQuery();
        }
    }
