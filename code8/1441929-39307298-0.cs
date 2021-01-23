        DataTable dt = new DataTable();
        dt.Columns.Add("name1", typeof(string));
        dt.Columns.Add("name2", typeof(string));
        dt.Columns.Add("name3", typeof(string));
        dt.Columns.Add("name4", typeof(string));
        dt.Columns.Add("name5", typeof(string));
        for (int i = 0; i < 6; i++)
        {
            try
            {
                dt.Rows.Add("a", "b", "c", "d", "e");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        dataGridView1.DataSource = dt;
