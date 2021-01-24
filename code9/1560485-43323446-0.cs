    //byte array that will hold image data
    byte[] imageData = null;
    
    using (var ms = new MemoryStream())
    {
        //here is image property of your pictureBox control  saved into memory stream
    	pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    	imageData = ms.ToArray();
    }
    
    //make sql connection
    SqlConnection conn = new SqlConnection("your connection string goes here");
    // command with parameter
    SqlCommand cmd = new SqlCommand("insert into TableWithImages (imageData) values (@imageData);", conn);
    //define param and pass byte array as value
    cmd.Parameters.Add("@imageData", SqlDbType.VarBinary).Value = imageData;
    
    //do insert
    cmd.ExecuteNonQuery();
