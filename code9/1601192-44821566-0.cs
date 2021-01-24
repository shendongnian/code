    var dataTable = ((DataTable)dataGridView1.DataSource).GetChanges();
    if(dataTable != null && dataTable.Rows.Count > 0)
    {
      foreach (DataRow row in dataTable.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        // DO INSERT QUERY
                        break;
                    case DataRowState.Deleted:
                        // DO DELETE QUERY
                        break;
                    case DataRowState.Modified:
                        SqlCommand command = new SqlCommand("UPDATE YOURTABLE SET TypNastaveniaID = @typ, Nazov = @title, Hodnota = @amount");
                        command.Parameters.Add(new SqlParameter("@typ", row["TypNastaveniaID"]));
                        command.Parameters.Add(new SqlParameter("@title", row["Nazov"]));
                        command.Parameters.Add(new SqlParameter("@amount", row["Hodnota"]));
                        command.ExecuteNonQuery();
                        break;
                }
            }
        ((DataTable)dataGridView1.DataSource).AcceptChanges();
    }
