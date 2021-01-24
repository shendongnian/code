    MySqlCommand command = new MySqlCommand(updateQuery, connection);
    command.Parameters.Add("@qty", MySqlDbType.VarChar).Value = AddStock.Text;
    command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(txtGameID.Text);
    if (command.ExecuteNonQuery() > 0)
         ....
