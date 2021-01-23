    SqlConnection con1;
    con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User1\Documents\ESDB.mdf;Integrated Security=True;Connect Timeout=30");
    con1.Open();
    string qry = "Insert into QRCODES(Image) VALUES(@PIC)";
    SqlCommand cmd = new SqlCommand(qry);
    ^^^^^^^^^^           ^^^^^^^^^^
    MemoryStream STREAM = new MemoryStream();
    pictureBox1.Image.Save(STREAM, System.Drawing.Imaging.ImageFormat.Jpeg);
    byte[] pic = STREAM.ToArray();
    cmd.Parameters.AddWithValue("@PIC", pic);
    cmd.ExecuteNonQuery();
    cmd.Dispose();
    con1.Close();
