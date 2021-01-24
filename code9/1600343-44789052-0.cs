    con.Open();
            string str = "select * from engineering where JobNumber like '%' + @search + '%' ";
    if(chkEducational.Checked)
    str += "AND Education = @Education";
    SqlCommand xp = new SqlCommand(str.ToString(), con);
     xp.Parameters.Add("@search", SqlDbType.NVarChar).Value =  txtProjectNumber.Text;
    xp.Parameters.Add("@Education", SqlDbType.Int).Value = chkEducational.CheckState;
    try
            {
                
                da = new SqlDataAdapter();
                da.SelectCommand = xp;
                da.Fill(ss);
                Showdata(pos);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView1.DataSource = ds.Tables["ss"];
            }
            catch
            {
                MessageBox.Show("No Record Found");
            }
            
            
            con.Close();
