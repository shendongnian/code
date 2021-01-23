    Image img = Image.FromFile(@"C:\Users\Awais\Desktop\image.png");
    byte[] arr;
    using (MemoryStream ms = new MemoryStream())
    {
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        arr = ms.ToArray();
    }
    int dr = 0;
    SqlConnection con = new SqlConnection("data source=.; initial catalog=database; uid=sa;pwd=password;");
    SqlCommand cmd = new SqlCommand("update table set I1 = @img", con);
    cmd.Parameters.AddWithValue("@img", arr);
    con.Open();
    using (con)
    {
        dr = cmd.ExecuteNonQuery();
    }
