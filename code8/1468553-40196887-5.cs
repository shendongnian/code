    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User1\Documents\ESDB.mdf;Integrated Security=True;Connect Timeout=30"))
    {
        con1.Open();
        string qry = "Insert into QRCODES(Image) VALUES(@PIC)";
        using (SqlCommand cmd = con1.CreateCommand()) //associate the connection to the command
        {
            cmd.CommandText = qry; //assign the command text to the command.
            using (var STREAM = new MemoryStream())
            {
                pictureBox1.Image.Save(STREAM, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = STREAM.ToArray();
    
                cmd.Parameters.AddWithValue("@PIC", pic);
                cmd.ExecuteNonQuery();
                con1.Close();
            }
        }
    }
