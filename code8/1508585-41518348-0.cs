     SqlConnection con = new SqlConnection("Data Source=SERVERNAME;Initial Catalog=DATABASENAME;Integrated Security=SSPI;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select picbox from picture1 where id=1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["picbox"]);
                pictureBox1.Image = new Bitmap(ms);
            }
