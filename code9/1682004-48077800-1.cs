    if(pb1 != null) 
    { 
        MemoryStream stream = new MemoryStream();
        pb1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] pic = stream.ToArray();
        command.Parameters.AddWithValue("@image", pic);
    }
    else 
    {
        command.Parameters.AddWithValue("@image", System.Data.SqlTypes.SqlBinary.Null); 
        // edit: DBNull.Value due to comment by Heinzi
    }
