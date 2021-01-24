    ...
    MySqlCommand cmd = new MySqlCommand(query, con);
    DataTable dt = new DataTable();
    cmd.Paramters.Add("@STUDENT_NO", MySqlDbType.Int); .. guessing this is an int - otherwise choose type
    cmd.Paramters.Add("@NAME", MySqlDbType.String);
    ... // add rest here
    con.Open();
    ...
    for (.. ) {
        ...
        int studentno;
        int.TryParse(dataGridView1.Rows[i].Cells["STUDENT NO"].Value.ToString(), out studentno);
        cmd.Paramters["@STUDENT_NO"].Value = studentno;
        cmd.Paramters["@NAME"].Value = dataGridView1.Rows[i].Cells["NAME"].Value.ToString();
        ...
    }
