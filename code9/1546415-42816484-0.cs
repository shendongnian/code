    protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            foreach (var item in Application.OpenForms)
            {
                DataSet dataSet = new DataSet();
                using (SqlConnection connection= new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(SelectStatement,connection));
                    adapter.Fill(dataSet);
                }
                if (item.GetType()==typeof(parentForm))
                {
                    (item as Form1).dataGridView1.DataSource = dataSet.Tables[0];
                }
            }
        }
