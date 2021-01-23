    MySqlConnection con = new MySqlConnection(conStr);
    try 
    {
	    con.Open();
	    MySqlCommand cmd = new MySqlCommand(con);
	    cmd.CommandText = "UPDATE table_name SET field_name_1 = ?param1, field_name_2 = ?param2 WHERE id = ?id";
	    cmd.Parameters.Clear();
	    cmd.Parameters.AddWithValue("?param1", value1);
	    cmd.Parameters.AddWithValue("?param2", value2);
	    cmd.Parameters.AddWithValue("?id", value3);
	    cmd.ExecuteNonQuery(); 
    }
    catch (MySqlException ee)
    {
	     MessageBox.Show(ee.Message);
    }
    finally
    {
	    con.Close();
	    con.Dispose();
    }
