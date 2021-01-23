    // Define here just once
    var paramRecord = command.Parameters.Add("@record");
    // the other parameters
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        paramRecord.Value = dataGridView1.Rows[i].Cells["Record"].Value.ToString());
        // other parameter values here
        scm.ExecuteNonQuery();
    }
