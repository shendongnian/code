    public void btnSave_Click(object sender, EventArgs e)
    {
    @fname = txtfname.Text;
    @lname = txtlname.Text;
    byte[] @img1 = ImageToByte2(pictureBox1.Image);
    con = new SqlConnection(@"Data Source=DESKTOP-400N4CL;Initial Catalog=test;Integrated Security=True");
    con.Open();
    cmd = new SqlCommand("INSERT INTO dbo.fingerp " + " (fname,lname,finprint) " + " VALUES(@fname,@lname,@img1)", con);
    cmd.Parameters.AddWithValue("@fname", txtfname.Text);
    cmd.Parameters.AddWithValue("@lname", txtlname.Text);
    cmd.Parameters.AddWithValue("@img1", @img1);
    cmd.ExecuteNonQuery();
}
    public static byte[] ImageToByte2(Bitmap img)
    {
    using (var stream = new MemoryStream())
    {
    img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
    return stream.ToArray();
    }
    }
