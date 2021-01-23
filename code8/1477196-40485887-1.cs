    public void load_grid()
        {
            dt.Clear();
            SqlDataAdapter da1 = new SqlDataAdapter();
            try
            {
                string sql = "SELECT * FROM profile";
                con.Open();
                da1.SelectCommand = new SqlCommand(sql, con);
                da1.Fill(ds);
                da1.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State != System.Data.ConnectionState.Closed)
                    con.Close();
            }
        }
     private void button1_Click(object sender, EventArgs e)
            {
                string ac = textBox1.Text;
                string bd = textBox2.Text;
                string sex = textBox2.Text;
                string sql = "INSERT INTO profile(ac,bd,sex)VALUES('" + ac + "','" + bd + "','" + sex + "')";
                try
                {
                    con.Open();
                    da = new SqlDataAdapter();
                    da.InsertCommand = new SqlCommand(sql, con);
                    da.InsertCommand.ExecuteNonQuery();
                    da.Update(dt);
                    con.Close();
                    MessageBox.Show("INsert success...!!");
                    load_grid();               
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con.State != System.Data.ConnectionState.Closed)
                        con.Close();
                }
            }
