    string connectionString = "Data Source=localhost, 3306;
    Initial Catalog=EliseDB;User ID=root"
    SqlConnection cnn = new SqlConnection(connectionString)
    try
    {
        cnn.Open();
        MessageBox.Show("Opened connection!");
        cnn.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Big Problem: " + ex.message);
    }
