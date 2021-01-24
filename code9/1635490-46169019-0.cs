     try
            {
                int i=0;
                double credit=0.00, debit=0.00;
                MySqlCommand cmd = new MySqlCommand("select accounts,credit,debit from tbl_open_balance where status='A'", con);
                dr=cmd.ExecuteReader();
                while(dr.Read())
                {
                    if (dataGridView1.Rows.Count < i + 1) dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value=dr["accounts"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["credit"].ToString();
                    credit = credit + Convert.ToDouble(dr["credit"].ToString());
                    dataGridView1.Rows[i].Cells[2].Value = dr["debit"].ToString();
                    debit = debit + Convert.ToDouble(dr["debit"].ToString());
                    dataGridView1.Rows.Add();
                    i++;
                }
                dataGridView1.Rows[i].Cells[0].Value = "Credit";
                dataGridView1.Rows[i].Cells[1].Value = "";
                dataGridView1.Rows[i].Cells[2].Value = credit.ToString();
                dataGridView1.Rows.Add();
                i++;
                dataGridView1.Rows[i].Cells[0].Value = "Debit";
                dataGridView1.Rows[i].Cells[1].Value = "";
                dataGridView1.Rows[i].Cells[2].Value = debit.ToString();
                dataGridView1.Rows.Add();
                i++;
                dataGridView1.Rows[i].Cells[0].Value = "Total";
                dataGridView1.Rows[i].Cells[1].Value = "";
                dataGridView1.Rows[i].Cells[2].Value = (credit - debit).ToString();
                dataGridView1.Rows.Add();
                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238,239,249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dr.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
            }
