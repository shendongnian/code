    //Insert image
    SqlCommand comm = new SqlCommand("Insert into ImageColumn values (@Image)")
    comm.Parameters.AddWithValue("@Image",  Converter.GetBytes(pictureBox.image));
    //Retrieving image
    pictureBox1.Image = Converter.GetImage(dataTable.Rows[0]["ImageColumn"])
    //Converter class
    class Converter
    {
        public static byte[] GetBytes(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public static byte[] GetBytes(string path)
        {
            using (var ms = new MemoryStream())
            {
                Image img = Image.FromFile(path);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public static Image GetImage(byte[] buffer)
        {
            using (var ms = new MemoryStream(buffer))
            {
                return Image.FromStream(ms);
            }
        }
    }
