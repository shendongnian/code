    // Define here just once
    var paramRecord = scm.Parameters.Add("@record", System.Data.SqlDbType.Variant ); // There are 6 Add methods in total. 5 of them return SqlParameter so you can use any of those 5
    // the other parameters
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        paramRecord.Value = dataGridView1.Rows[i].Cells["Record"].Value.ToString());
        // other parameter values here
        scm.ExecuteNonQuery();
    }
