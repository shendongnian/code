        ////sql connection codes here
        SqlDataReader dr = cmd.ExecuteReader();    
        while (dr.Read())    
        {    
        byte[] picture = (byte[])dr[0];
        MemoryStream ms = new MemoryStream(picture, 0, picture.Length); 
        ms.Write(picture, 0, picture.Length);    
        RegPicture = Image.FromStream(ms, true);
        pictureBox1.Image = RegPicture;    
        }
        ////sql connection codes here
