    varbinary(MAX)
    byte[] bytes;
            using (BinaryReader br = new BinaryReader(photo.PostedFile.InputStream))
            {
                bytes = br.ReadBytes(photo.PostedFile.ContentLength);
            }
            SqlCommand cmd = new SqlCommand("insert into img values('@harikesh')", cn);
            cn.Open();
            cmd.Parameters.AddWithValue("@harikesh", bytes);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("<script language='javascript'>alert('inserted sucess')</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('NOT sucess')</script>");
            }
            cn.Close();`
