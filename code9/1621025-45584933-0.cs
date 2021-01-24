    dataGridView1.AutoGenerateColumns = true;
    SQLiteConnection dbConnection = new SQLiteConnection("Data Source=C:\\Data\\SODB.db;Version=3;");
    dbConnection.Open();
    
    dataGridView1.DataSource = null;
    dataGridView1.Columns.Clear();
    dataGridView1.Rows.Clear();
    SQLiteDataAdapter adp = new SQLiteDataAdapter("SELECT item_id, item_name, sup_name FROM  product, suppliers1 where product.sup_id = suppliers1.sup_id", dbConnection);
    DataTable dt = new DataTable();            
    adp.Fill(dt);
    dataGridView1.DataSource = dt;
    
    dbConnection.Close();
