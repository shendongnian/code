    SqlConnection con2 = new SqlConnection(conString);
    con2.Open();
    if (con2.State == System.Data.ConnectionState.Open)
    {
        string sss = "SELECT student_photo from student_reg where reg_year=@YEAR and s_id=@ID";
        SqlCommand cmd = new SqlCommand(sss, con2);
        cmd.Parameters.AddWithValue("@YEAR", year);
        cmd.Parameters.AddWithValue("@ID", sid_lbl.Text);
        Byte[] getImg = (Byte[])cmd.ExecuteScalar();
        MemoryStream stream = new MemoryStream(getImg);
        Image img = Image.FromStream(stream);
        picturebox1.Image = img;
    }
    con2.Close()
