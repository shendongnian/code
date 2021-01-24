      private void fill_div()
        {
            var com = new MySqlCommand("Select *From shtrn where mem_no ='" + textBox1.Text + "' order by tdate  ", con_db.con);
            var dr = com.ExecuteReader();
            try
            {
                dgview2.Rows.Clear();
                while (dr.Read())
                {
                    var n = dgview2.Rows.Add();
                    dgview2.Rows[n].Cells[0].Value = Convert.ToDateTime(dr["tdate"].ToString());
                    dgview2.Rows[n].Cells[1].Value = dr["particular"].ToString();
                    dgview2.Rows[n].Cells[2].Value = dr["trmode"].ToString();
                    dgview2.Rows[n].Cells[3].Value = dr["debit"].ToString();
                    dgview2.Rows[n].Cells[4].Value = dr["credit"].ToString();
                    dgview2.Rows[n].Cells[5].Value = dr["balance"].ToString();
                    dgview2.FirstDisplayedScrollingRowIndex = n;
                    dgview2.CurrentCell = dgview2.Rows[n].Cells[0];
                    UpdateBalance();
                }
                {
                    dr.Close();
                }
               
            }
            catch (FormatException)
            {
                MessageBox.Show("No Records Found ");
            }
        }
