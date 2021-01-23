        SqlCommand cmd = new SqlCommand();
        byte[] images = null;
        using (SqlDataReader dataread = cmd.ExecuteReader())
        {
            if (dataread.Read())
            {
                //lblstudnum.Text = dataread[0].ToString();
                //lblcourse.Text = dataread[1].ToString();
                //lblfname.Text = dataread[2].ToString();
                //lbllname.Text = dataread[3].ToString();
                images = (byte[])dataread["color_image"];// column name is recommended
            }
        }
        if (images == null)
        {
            pictureBox1.Image = null;
        }
        else
        {
            MemoryStream mstreem = new MemoryStream(images);
            pictureBox1.Image = Image.FromStream(mstreem);
        }
