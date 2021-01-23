    private void button2_Click(object sender, EventArgs e)
    {           
        String strCn =@"Data Source=DESKTOP-ROF2H0M\BHAGI;Initial Catalog=Golden;Integrated Security=True";
        SqlConnection cn = new SqlConnection(strCn);
        cn.Open();
        try
        {
        //Retrieve BLOB from database into DataSet.
        SqlCommand cmd = new SqlCommand("SELECT User_id ,img FROM login", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "login");
        int c = ds.Tables["login"].Rows.Count;
            if (c > 0)
            {   //BLOB is read into Byte array, then used to construct MemoryStream,
                //then passed to PictureBox.
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])(ds.Tables["login"].Rows[c-1]["img"]);
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                pictureBox1.Image = Image.FromStream(stmBLOBData);
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
                cn.close();
            }
        }
    }
