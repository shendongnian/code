    string[] columnNames = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                                .Select(x => x.HeaderText).ToArray();
    // get column names to string array
    string joinedArray = string.Join(",", columnNames);
    // set them into string seperating with ,
    string sql = "INSERT INTO tableName VALUES (" + joinedArray + ")";
