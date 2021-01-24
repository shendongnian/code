    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 1) //Assuming Checkbox is displayed in 2nd column.
        {
            this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            var result = this.dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            var userName = this.dataGridView1[0, e.RowIndex].Value; //Assumin username is displayed in fist column
            var connectionString = "Your Connection String";
            //Set value of your own connection string above.
            var sqlQuery = "UPDATE UsersNotified SET AllowNotification = @allowNotification WHERE UserName = @userName";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@allowNotification", SqlDbType.Bit).Value = result;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
