    const string parancs = 
        "UPDATE Equipment SET {column-name} = @Value, Modifier = @Modifier, Modified = @Modified " +
        "WHERE Description = @Description AND [Plane_A/C] = @Plane";
    DateTime time = DateTime.Now;
    foreach (DataGridViewRow row in dataGridView.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            if (cell.Value == null)
            {
                cell.Value = DBNull.Value;
            }
        }
    }
    using (connection)
    using (var sqlComm = connection.CreateCommand())
    {
        connection.Open();
        for (int i = 0; i < rowIndexes.Count; i++)
        {
            sqlComm.Parameters.Clear();
            sqlComm.Parameters.AddWithValue("@Value", dataGridView.Rows[rowIndexes[i]].Cells[columnIndexes[i]].Value);
            sqlComm.Parameters.AddWithValue("@Description", dataGridView.Rows[rowIndexes[i]].Cells["Description"].Value);
            sqlComm.Parameters.AddWithValue("@Plane", ChoosenAC);
            sqlComm.Parameters.AddWithValue("@Modifier", "TesztAdmin");
            sqlComm.Parameters.AddWithValue("@Modified", time);
            sqlComm.CommandText = parancs.Replace("{column-name}", dataGridView.Columns[columnIndexes[i]].HeaderText);
            try
            {
                sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        sqlComm.Connection.Close();
    }
    MessageBox.Show("Sikeres módosítás!");
