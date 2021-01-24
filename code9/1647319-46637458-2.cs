    public void fillgrid(string qry, GridView dg){
            try
            {
                sql.cmd = new SqlCommand("qry", sql.cn);
                sql.cn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(sql.cmd);
                sda.Fill(ds);
                dg.DataSource = ds;
                dg.DataBind();
                sql.cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
