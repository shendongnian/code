    private void fillDataGrid(DataGridView dg, string query) {
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            
            SqlDataAdapter oda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try {
                conn.Open();
                cmd.ExecuteNonQuery();
                oda.Fill(dt);
                conn.Close();
                dg.DataSource = dt;
            }
            catch(Exception e) {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                
            }
        }
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                String s = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String upit = "Select * from CARD_NO where CT_ID = " + s + "";
                fillDataGrid(dataGridView2, upit);
            }
            
        }
    private void Form1_Load(object sender, EventArgs e)
        {
            fillDataGrid(dataGridView1, "Select * from CARD_TYPE");
        }
