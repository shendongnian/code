    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SARManagement;Data Source=AIZAZ\SQLEXPRESS");
            con.Open();
            string query = "Select Semester,ID FROM Batch";
            SqlCommand da = con.CreateCommand();
            da.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(da);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Batch");
            Semester.ItemsSource = ds.Tables[0].DefaultView;
            Semester.DisplayMemberPath = "Semester";
            Semester.SelectedValuePath = "ID";
        }
        catch (Exception ex)
        {
            MessageBox.Show("" + ex);
        }         
    }
    private void Semester_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DataRowView data = (DataRowView)Semester.SelectedItem;
        string selstr = data["Semester"].ToString();
        int sel = (int)data["ID"];
        MessageBox.Show("ID: " + sel + " Value: " + selstr);
    }
