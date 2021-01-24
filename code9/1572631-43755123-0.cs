    Image myImage = null;
    if (!(dr["Image"] is DBNull))
    {
       byte[] b = (Byte[])(dr["Image"]);
       using (MemoryStream ms = new MemoryStream(b, 0, b.Length))
       {
            ms.Write(b, 0, b.Length);
            myImage = Image.FromStream(ms, true);
       }
    }
    pictureBox1.Image = myImage;
