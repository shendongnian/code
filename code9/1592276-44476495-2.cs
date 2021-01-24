    if (count == 1)
    {
        var command = new MySqlCommand("update test.auth SET bits = bits + @bits where id = @id;", myConn);
        command.Parameters.AddWithValue("@bits", materialSingleLineTextField4.Text);
        command.Parameters.AddWithValue("@id", materialSingleLineTextField3.Text);
        command.ExecuteNonQuery();
        materialFlatButton6.Text = "Bits have been transferred!";
    }
