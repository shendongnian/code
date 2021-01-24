    byte[] picData = (byte[])dr[1];
    if (picData[0] == 0)
    {
      pictureBox1.Image = null;
    }
    else
    {
      MemoryStream ms = new MemoryStream(picData);
      ms.Position = 0;
      pictureBox1.Image = new Bitmap(ms);
    }
