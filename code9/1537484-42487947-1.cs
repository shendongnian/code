       var columns = new System.Text.StringBuilder();
       var values = new System.Text.StringBuilder();
       MySqlCommand cmd = connection.CreateCommand();
       for (int i = 0; i < textboxes.Count; i++)
       {
           var value = textboxes[i];
           var column = labels[i];
           cmd.Parameters.AddWithValue("@" + column.Name, value.Text);
           string complement = (i == 0 ? string.Empty : ",");
           columns.Append(complement + column.Name);
           values.Append(complement + "@" + column.Name);
       }
       cmd.CommandText = "INSERT INTO firmenkunden (" + columns.ToString() + ") VALUES (" + values.ToString() + ")";
