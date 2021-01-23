    private void button2_Click(object sender, EventArgs e)
    {           
        string strCn = @"Data Source=DESKTOP-ROF2H0M\BHAGI;Initial Catalog=Golden;Integrated Security=True";
            using (var cn = new SqlConnection(strCn))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SELECT User_id ,imgUrlOnDisk FROM login", cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    pictureBox1.Image = Image.FromFile(Convert.ToString(dr["imgUrlOnDisk"]));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (cn.State != ConnectionState.Closed)
                    {
                        cn.Close();
                    }
                }
            }
    }
