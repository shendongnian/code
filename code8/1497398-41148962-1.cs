    string sql = "The first query"
    SqlDataAdapter dataadapter = new SqlDataAdapter(sql, myConnection);
    DataSet ds = new DataSet();
    myConnection.Open();
    dataadapter.Fill(ds, "Authors_table");
    myConnection.Close();
    // I don't know what your primary key is, but you need to have one.
    // I am assuming it's called "author_id".
    DataColumn authorIdColumn = ds.Tables["Authors_table"].Columns["author_id"];
    ds.Tables["Authors_table"].PrimaryKey = new[] { authorIdColumn };
    // Get your second set of data
    sql = "My second query, which also has the same primary key, but has more columns"
    dataadapter = new SqlDataAdapter(sql, myConnection);
    dataadapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    DataSet ds2 = ds.Clone();
    myConnection.Open();
    dataadapter.Fill(ds2, "Authors_table");
    myConnection.Close();
    // Now we use the DataSet.Merge method, which is very powerful. 
    ds.Merge(ds2, false, MissingSchemaAction.AddWithKey);
    dataGridView1.DataSource = ds;
    dataGridView1.DataMember = "Authors_table";
