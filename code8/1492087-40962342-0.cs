    var query = "update DBTable set price=@price where ParamToCheck=@prm";
    using (SqlConnection myconnection = new SqlConnection(con))
    using (SqlCommand cm = new SqlCommand(query, myconnection))
    {
        try
        {
            myconnection.Open();     
            cm.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(textBox2.Text);
            cm.Parameters.Add("@prm", SqlDbType.NVarChar).Value = comboBox5.Text;
            int rowsUpdated = cm.ExecuteNonQuery();
            if(rowsUpdated > 1)
                 MessageBox.Show("saved ok !!");     
            else
                 MessageBox.Show("No match for condition:" + comboBox5.Text);     
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
