    private void bUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connection);
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            var newValueValue = dataGridView1.Rows[i.Cells[10].Value;
            if (newValueValue == null)
            {
                newValueLen = 0;
            }
            else
            {
                newValueLen = dataGridView1.CurrentRow.Cells[10].Value.ToString().Length;
            }
            if (newValueLen > 0)
            {
                // Instantiate values here, so you don't need to reset them every time
                var newValue= dataGridView1.CurrentRow.Cells[10].Value.ToString();
                var lineKey = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var logValues = 
                    $"newValue = {newValue}; LineKey = {lineKey}; Cycle = {i}; newValueLen = {newValueLen}";                
            
                var query = "INSERT INTO tErrorLog SELECT @LogValues";
                using (var conn = new SqlConnection(connection))
                using (var command = new SqlCommand(query, conn))
                {
                    var parameter = new SqlParameter
                    {
                        ParameterName = "@LogValues", // Should be same as in query
                        SqlDbType = SqlDbType.VarChar, // Use actual type from your database
                        Size = 300, // Use actual size of your column in database
                        Value = logValues
                    };
                    command.Parameters.Add(parameter);
                    conn.Open
                    command.ExecuteNonQuery();
                }
            }
        }
    }
