    using (var conn = new NpgsqlConnection(<connection string>)) {
        var command = new NpgsqlCommand("UPDATE dbschema.dbtable SET senha = '" + textBox2.Text + "' WHERE rg = '" + textBox2.Text + "'", conn);
    	conn.Open();
        command.ExecuteNonQuery();
    }
