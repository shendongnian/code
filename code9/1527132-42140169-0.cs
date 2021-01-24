    private void desempenho_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select desc from vidros where desempenho ='" + desempenho.Text + "'", con);
            DataTable DTT = new DataTable();
            sda.Fill(DTT);
            checkedListBox1.Items.Clear();
            foreach (DataRow AB in DTT.Rows)
            {
                checkedListBox1.Items.Add(AB["desc"].ToString());
            }
        }
